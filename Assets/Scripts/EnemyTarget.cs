using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
