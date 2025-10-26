using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isGameFinished = false;
    float restartDelay = 2f;

    public UIManager uiManager;
    public ScoreManager scoreManager;

    public void CompleteLevel()
    {
        Debug.Log("Level Complete");
        uiManager.ShowCompleteLevelUI();
    }

    public void EndGame()
    {
        if (!isGameFinished)
        {
            isGameFinished = true;
            int score = scoreManager.GetScore();
            scoreManager.SaveHighScore(score);
            Invoke(nameof(RestartGame), restartDelay);
        }
    }

    public void RestartGame()
    {
        uiManager.HideCompleteLevelUI();
        isGameFinished = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
