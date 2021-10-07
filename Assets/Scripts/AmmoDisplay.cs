using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] private Text ammoText;
    [SerializeField] private Gun gun;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Text healthText;

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + gun.ammoCount.ToString();
        healthText.text = "Health: " + playerHealth.health.ToString();
    }
}
