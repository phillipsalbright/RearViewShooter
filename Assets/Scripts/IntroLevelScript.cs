using System.Collections;
using UnityEngine;

/**
 * This script is attached to an empty object with a Panel as a child and manages that Panel
 * to act as the introductory message that appears when the tutorial is started. Also manages
 * some logic specific to the tutorial level. This script is not very useful outside of the
 * specific tutorial level.
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
    /** Set to "PauseMenuController" child or playerWhole to deactivate pause menu while messages are being displayed */
    public GameObject pauseMenu;
    public GameObject playerUI;

    /** Objects to be moved during certain segments of the tutorial */
    public Transform sign1;
    public Transform slidingDoor1;

    void Start()
    {
        StartCoroutine(StartLogic());
    }

    public void CloseIntroText()
    {
        introText.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 1;
        player.GetComponent<PlayerLook>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator StartLogic()
    {
        yield return new WaitForSeconds(.5f);
        pauseMenu.SetActive(false);
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
            playerUI.SetActive(true);
            Destroy(propGun);
            gun.SetActive(true);
            StartCoroutine(MoveSlidingDoor1());
            StartCoroutine(MoveSign1());
        }
    }

    /**
     * Moves the first sliding door gradually.
     */
    private IEnumerator MoveSlidingDoor1()
    {
        while (slidingDoor1.localPosition.z > -17.2f)
        {
            slidingDoor1.localPosition = new Vector3(slidingDoor1.localPosition.x, slidingDoor1.localPosition.y, slidingDoor1.localPosition.z - .01f);
            yield return new WaitForSeconds(.0001f);
        }
    }

    /**
     * Moves the first sign door gradually.
     */
    private IEnumerator MoveSign1()
    {
        while (sign1.localPosition.z > -3.18f)
        {
            sign1.localPosition = new Vector3(sign1.localPosition.x, sign1.localPosition.y, sign1.localPosition.z - .01f);
            yield return new WaitForSeconds(.05f);
        }
    }
}
