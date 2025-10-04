using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool isGameFinished = false;
    float restartDelay = 2f;
    bool isPaused = false;

    public int forwardForce = 2000;
    public int maxForwardForce = 50000;

    public Button button;
    public Sprite pauseImg;
    public Sprite resumeImg;
    public Text scoreText;
    public Text highScoreLabelText;
    public Rigidbody rb; // Player

    public GameObject completeLevelUI;

    // For Tutorial
    public Text TapLeft;
    public Text TapRight;


    void FixedUpdate()
    {
        string firstRun = PlayerPrefs.GetString("FirstRun");
        if (firstRun == "")
        {
            Debug.Log("FIRSTRUN -" + firstRun);
            forwardForce = 1000;
            int score = int.Parse(scoreText.text);
            if (score > 2 & score < 10)
            {
                TapLeft.text = "TAP HERE TO SLIDE LEFT";
            }
            else if (score > 10 & score < 15)
            {
                TapLeft.text = "";
                TapRight.text = "TAP HERE TO SLIDE RIGHT";
            }
            else if (score > 20)
            {
                forwardForce = 2000;
                TapLeft.text = "";
                TapRight.text = "";
                PlayerPrefs.SetString("FirstRun", "true");
            }
            else
            {
                TapLeft.text = "";
                TapRight.text = "";
            }
        }
        else
        {
            ObstacleForwardForce();
        }
    }

    public void CompleteLevel()
    {
        Debug.Log("Level Complete");
        completeLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        if (!isGameFinished)
        {
            isGameFinished = true;
            int score = int.Parse(scoreText.text);
            SaveHighScore(score);
            //Invoke(nameof(PauseGame), restartDelay);
            Invoke(nameof(RestartGame), restartDelay);
        }
    }
    public void RestartGame()
    {
        completeLevelUI.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void onPause()
    {
        if (rb.position.y > -1f)
        {
            if (isPaused)
            {
                isPaused = false;
                button.GetComponent<Image>().sprite = pauseImg;
                ResumeGame();
            }
            else
            {
                isPaused = true;
                scoreText.text = "PAUSED";
                highScoreLabelText.text = "";
                button.GetComponent<Image>().sprite = resumeImg;
                PauseGame();
            }
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public int ObstacleForwardForce()
    {
        int Score = FindFirstObjectByType<BlockSpawner>().waveCount;
        if (Score % 10 == 0 && forwardForce < maxForwardForce)
        {
            forwardForce++;
        }

        return forwardForce;
    }

    public void SaveHighScore(int score)
    {
        int currentScore = PlayerPrefs.GetInt("HighScore");

        if (score > currentScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void GameData(string action, string type, string key, string value)
    {
        if (action == "save")
        {
            if (type == "int")
            {
                PlayerPrefs.SetInt(key, int.Parse(value));
            }
            else if (type == "float")
            {
                PlayerPrefs.SetFloat(key, float.Parse(value));
            }
            else if (type == "String")
            {
                PlayerPrefs.SetString(key, value);
            }
        }
        else if (action == "load")
        {
            if (type == "int")
            {
                PlayerPrefs.GetInt(key);
            }
            else if (type == "float")
            {
                PlayerPrefs.GetFloat(key);
            }
            else if (type == "String")
            {
                PlayerPrefs.GetString(key);
            }
        }
    }
}
