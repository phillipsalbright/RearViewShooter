using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject Player;
    public int currentLevel;

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }
    public void Death()
    {
        Time.timeScale = 0;
        deathScreen.SetActive(true);
        Player.GetComponent<PlayerLook>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}