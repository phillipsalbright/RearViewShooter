using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public bool Paused = false;

    /** Set these gameObjects in the editor */
    public GameObject Player;
    public GameObject PauseMenu;
    public Gun gun;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused == false)
            {
                gun.enabled = false;
                Time.timeScale = 0;
                Paused = true;
                PauseMenu.SetActive(true);
                Player.GetComponent<PlayerLook>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            } else
            {
                UnpauseGame();
            }
        }
    }

    public void UnpauseGame()
    {
        gun.enabled = true;
        Player.GetComponent<PlayerLook>().enabled = true;
        Paused = false;
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
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

    public void RestartLevel()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
