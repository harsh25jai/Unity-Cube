using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text tapLeft;
    public Text tapRight;

    private bool firstRun = true;

    public void CheckFirstRun(int score)
    {
        if (firstRun)
        {
            string firstRunStatus = PlayerPrefs.GetString("FirstRun");
            if (string.IsNullOrEmpty(firstRunStatus))
            {
                SetupTutorial(score);
            }
        }
    }

    private void SetupTutorial(int score)
    {
        if (score > 2 && score < 10)
        {
            tapLeft.text = "TAP HERE TO SLIDE LEFT";
        }
        else if (score > 10 && score < 15)
        {
            tapLeft.text = "";
            tapRight.text = "TAP HERE TO SLIDE RIGHT";
        }
        else if (score > 20)
        {
            tapLeft.text = "";
            tapRight.text = "";
            PlayerPrefs.SetString("FirstRun", "true");
            firstRun = false;
        }
        else
        {
            tapLeft.text = "";
            tapRight.text = "";
        }
    }
}
