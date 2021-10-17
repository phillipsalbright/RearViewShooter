using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This script is attached to an empty object with a Panel as a child and manages that Panel
 * to act as the introductory message that appears when the tutorial is started. Also manages
 * some logic specific to the tutorial level.
 */
public class IntroLevelScript : MonoBehaviour
{
    /** Introductory text set in the prefab. */
    public GameObject introText;
    /** Set this to the "Player" child of the "PlayerWhole" prefab within the scene */
    public GameObject player;
    /** Set this to the "Gun" child of the "PlayerWhole" prefab within the scene */
    public GameObject gun;
    /** Prop gun in the scene of the tutorial, destroyed when player "obtains the gun". Set within the prefab. */
    public GameObject propGun;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(propGun);
            gun.SetActive(true);
        }
    }
}
