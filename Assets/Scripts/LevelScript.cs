using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public int numberOfEnemies;
    private int currentNumberOfEnemies;
    public GameObject winScreen;
    public PlayerLook player;

    // Start is called before the first frame update
    void Start()
    {
        currentNumberOfEnemies = 9;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDied()
    {
        currentNumberOfEnemies--;
        if (currentNumberOfEnemies <= 0)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<PlayerLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
