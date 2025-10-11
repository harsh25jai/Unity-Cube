using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button button; // PauseButton
    public Sprite pauseImg;
    public Sprite resumeImg;
    public Text scoreText;
    public Text highScoreLabelText;
    public GameObject completeLevelUI;
    public Button backButton;

    private bool isPaused = false;

    void Update()
    {
        // Detect Android Back button or ESC key (for editor)
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HandleAndroidBackButton();
            }
        }
    }


    public void ShowCompleteLevelUI()
    {
        completeLevelUI.SetActive(true);
    }

    public void HideCompleteLevelUI()
    {
        completeLevelUI.SetActive(false);
    }

    public void OnPause()
    {
        if (isPaused)
        {
            isPaused = false;
            button.GetComponent<Image>().sprite = pauseImg;

            if (backButton != null)
                backButton.gameObject.SetActive(false);

            ResumeGame();
        }
        else
        {
            isPaused = true;
            scoreText.text = "PAUSED";
            highScoreLabelText.text = "";
            button.GetComponent<Image>().sprite = resumeImg;

            if (backButton != null)
                backButton.gameObject.SetActive(true); // Show Back button

            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void OnBackButtonPressed()
    {
        Time.timeScale = 1; // ensure game resumes time
        SceneManager.LoadScene(0); // Replace with your main menu scene name
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    private void HandleAndroidBackButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 0)
        {
            // If already on Main Menu exit app
            Application.Quit();
        }
        else
        {
            if (isPaused)
            {
                // If game is paused treat as "Back" to Main Menu
                OnBackButtonPressed();
            }
            else
            {
                // If game is running pause the game
                OnPause();
            }
        }
    }
}
