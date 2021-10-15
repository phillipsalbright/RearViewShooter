using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public float health = 30f;

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
