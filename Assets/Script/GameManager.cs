using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int itemsToCollect = 5;
    private int itemsCollected = 0;

    void Awake()
    {
        // Ensure there's only one instance of the GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectItem()
    {
        itemsCollected++;
        Debug.Log("Items Collected: " + itemsCollected);

        if (itemsCollected >= itemsToCollect)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You collected all items! You win!");
        // Implement win logic here (e.g., show win screen, load next level, etc.)
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        // Implement game over logic here (e.g., show game over screen, restart level, etc.)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the current level
    }
}
