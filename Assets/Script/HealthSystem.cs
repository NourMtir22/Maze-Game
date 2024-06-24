using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this if you want to display health on the UI

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Text healthText; // Reference to a UI Text element to display health

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        // Implement game over logic here (e.g., show game over screen, restart the game, etc.)
    }
}
