using UnityEngine;

public class GameController : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public ScoreManager scoreManager;

    void FixedUpdate()
    {
        int score = scoreManager.GetScore();
        tutorialManager.CheckFirstRun(score);
        scoreManager.UpdateForwardForce(score);
    }
}
