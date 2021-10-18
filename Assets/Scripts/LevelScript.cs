using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelScript : MonoBehaviour
{
    public int numberOfEnemies;
    public GameObject winScreen;
    public PlayerLook player;
    public int nextLevelSceneid;
    public GameObject gun;
    public GameObject pauseMenu;

    public void EnemyDied()
    {
        numberOfEnemies--;
        StartCoroutine(EndLevel());
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(2f);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
