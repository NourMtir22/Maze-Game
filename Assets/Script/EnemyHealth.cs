using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // You can add more logic here (e.g., play a death animation, drop loot, etc.)
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1); // Assume each bullet deals 1 damage
            Destroy(other.gameObject); // Destroy the bullet upon impact
        }
    }
}
