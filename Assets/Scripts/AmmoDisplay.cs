using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] private Text ammoText;
    [SerializeField] private Gun gun;
    [SerializeField] private PlayerHealth playerHealth;
    private LevelScript levelScript;
    [SerializeField] private Text healthText;
    [SerializeField] private Text zombieText;

    private void Awake()
    {
        levelScript = FindObjectOfType<LevelScript>();
    }

    void FixedUpdate()
    {
        ammoText.text = "Ammo: " + gun.ammoCount.ToString();
        healthText.text = "Health: " + playerHealth.health.ToString();
        zombieText.text = "Zombies Remaining: " + levelScript.GetNumberOfEnemies().ToString();
    }
}
