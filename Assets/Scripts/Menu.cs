using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text highscoreText;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        highscoreText.text = highScore.ToString("0");
    }
    public void StartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(2);
    }

}
