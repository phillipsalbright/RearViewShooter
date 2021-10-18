using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Class that handles player health/death calculations. Also calls the Gun when ammo Pickups are hit.
 * Can change value of health and ammo pickups here.
 */
public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 50f;
    public DeathScreen deathScreen;
    /** Set gun to this in editor */
    [SerializeField] private Gun gun;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        deathScreen.Death();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            if (health >= maxHealth)
            {
                return;
            }
            float newHealth = health + 10f;
            if (newHealth >= 50f)
            {
                health = 50f;
            } else
            {
                health = newHealth;
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.layer == 11)
        {
            if (gun.ammoCount >= gun.maxAmmo)
            {
                return;
            }
            int newAmmo = gun.ammoCount + 5;
            if (newAmmo > gun.maxAmmo)
            {
                gun.ammoCount = gun.maxAmmo;
            } else
            {
                gun.ammoCount = newAmmo;
            }
            Destroy(other.gameObject);
        }
    }
}
