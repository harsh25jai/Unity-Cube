using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int forwardForce = 2000;
    public int maxForwardForce = 50000;

    public UIManager uiManager;

    public int GetScore()
    {
        int score = 0;
        if (int.TryParse(uiManager.scoreText.text, out int parsedScore))
        {
            score = parsedScore;
        }
        return score;
    }

    public void SaveHighScore(int score)
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore");
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public int UpdateForwardForce(int score)
    {
        if (score % 10 == 0 && forwardForce < maxForwardForce)
        {
            forwardForce++;
        }

        return forwardForce;
    }
}
