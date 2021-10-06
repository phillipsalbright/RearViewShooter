using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    /** X axis sensitivity to be set in editor */
    [SerializeField] private float sensitivityX;

    /** Y axis sensitivity to be set in editor */
    [SerializeField] private float sensitivityY;

    /** Camera holder prefab within the scene */
    public Transform mainCamera;

    private float mouseX;

    private float mouseY;

    public float multiplier = .01f;
    
    private float xRotation;

    private float yRotation;

    /** Orientation of the player in the scene, gameobject attached to player keeping track of this */
    /** If player hitbox is not symmetrical on x/z plane, would have to change to rotate whole player */
    [SerializeField] private Transform orientation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void GetInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        yRotation += mouseX * sensitivityX * multiplier;
        xRotation -= mouseY * sensitivityY * multiplier;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
