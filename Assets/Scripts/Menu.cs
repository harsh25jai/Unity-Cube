using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text highscoreText;
    public Text highscoreLabelText;

    private void Start()
    {
        onFirstRun();

        int highScore = PlayerPrefs.GetInt("HighScore");
        highscoreText.text = highScore.ToString("0");
    }

    public void StartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(2);
    }

    public void onFirstRun()
    {
        string firstRunStatus = PlayerPrefs.GetString("FirstRun");

        bool firstRun = string.IsNullOrEmpty(firstRunStatus);

        if (highscoreLabelText != null)
            highscoreLabelText.gameObject.SetActive(!firstRun);

        if (highscoreText != null)
            highscoreText.gameObject.SetActive(!firstRun);


    }

}
