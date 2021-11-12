using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    public int numberOfEnemies;
    public GameObject winScreen;
    public PlayerLook player;
    public int nextLevelSceneid;
    public GameObject gun;
    public GameObject pauseMenu;
    private bool levelOver = false;
    private float startTime;
    private int thisSceneId;
    /** Contains all the strings that correspond to playerprefs for the best time on each level */
    private string[] levelHighScoreStrings = { "MainMenu", "Tutorial", "Level1", "Level2" };
    [SerializeField] private Text yourScoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Material finishLevelMat;
    private MeshRenderer endPlatformMesh;


    void Start()
    {
        startTime = Time.time;
        thisSceneId = SceneManager.GetActiveScene().buildIndex;
        endPlatformMesh = GetComponentInChildren<MeshRenderer>();
    }

    public void EnemyDied()
    {
        numberOfEnemies--;
        if (numberOfEnemies <= 0)
        {
            endPlatformMesh.material = finishLevelMat;
        }
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(1.5f);
        gun.SetActive(false);
        pauseMenu.SetActive(false);
        winScreen.SetActive(true);
        Time.timeScale = 0;
        player.GetComponent<PlayerLook>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(thisSceneId);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nextLevelSceneid);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            if (numberOfEnemies <= 0 && !levelOver)
            {
                float endTime = Time.time;
                float timeComplete = endTime - startTime;
                float highScore = PlayerPrefs.GetFloat(levelHighScoreStrings[thisSceneId], -1f);
                if (highScore < 0 || highScore > timeComplete)
                {
                    PlayerPrefs.SetFloat(levelHighScoreStrings[thisSceneId], timeComplete);
                    highScore = timeComplete;
                }
                yourScoreText.text = "Your Time: " + timeComplete.ToString() + " seconds";
                highScoreText.text = "Best Time: " + highScore.ToString() + " seconds";
                StartCoroutine(EndLevel());
                levelOver = true;
            }
        }
    }
}
