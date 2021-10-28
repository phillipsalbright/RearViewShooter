using UnityEngine;
using TMPro;

public class HighScoreMenu : MonoBehaviour
{
    /** Contains all the strings that correspond to playerprefs for the best time on each level. Should match LevelScript exactly. */
    private string[] levelHighScoreStrings = { "MainMenu", "Tutorial", "Level1", "Level2" };
    [SerializeField] private TextMeshProUGUI times;

    // Start is called before the first frame update
    void Start()
    {
        float tutorialTime = PlayerPrefs.GetFloat(levelHighScoreStrings[1], -1f);
        float level1Time = PlayerPrefs.GetFloat(levelHighScoreStrings[2], -1f);
        float level2Time = PlayerPrefs.GetFloat(levelHighScoreStrings[3], -1f);
        if (tutorialTime > 0)
        {
            times.text = "Tutorial: " + tutorialTime + "\n";
        } else
        {
            times.text = "Tutorial: Not yet completed\n";
        }
        if (level1Time > 0)
        {
            times.text += "Level 1: " + level1Time + "\n";
        }
        else
        {
            times.text += "Level 1: Not yet completed\n";
        }
        if (level2Time > 0)
        {
            times.text += "Level 2: " + level2Time + "\n";
        }
        else
        {
            times.text += "Level 2: Not yet completed\n";
        }
    }
    
}
