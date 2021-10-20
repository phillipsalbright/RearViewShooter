using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    /** All set within prefab */
    public GameObject deathScreen;
    public GameObject Player;
    public GameObject pauseMenu;
    public int currentLevel;

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }
    public void Death()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
        deathScreen.SetActive(true);
        Player.GetComponent<PlayerLook>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(currentLevel);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
