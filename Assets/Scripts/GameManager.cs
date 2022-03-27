using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isGameFinished = false;
    float restartDelay = 2f;

    public GameObject completeLevelUI;

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
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        completeLevelUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
