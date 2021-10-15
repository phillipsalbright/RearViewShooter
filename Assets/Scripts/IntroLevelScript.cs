using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroLevelScript : MonoBehaviour
{
    public GameObject introText;
    public GameObject player;

    void Start()
    {
        StartCoroutine(StartLogic());
    }

    public void CloseIntroText()
    {
        introText.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<PlayerLook>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator StartLogic()
    {
        yield return new WaitForSeconds(.5f);
        introText.SetActive(true);
        Time.timeScale = 0;
        player.GetComponent<PlayerLook>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
