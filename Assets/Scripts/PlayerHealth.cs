using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHeart = 5;
    public int currentHeart;

    [Header("Game Over")]
    public GameObject gameOverPanel;

    void Start()
    {
        currentHeart = maxHeart;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHeart -= damage;

        if (currentHeart <= 0)
        {
            currentHeart = 0;
            GameOver();
        }
    }

    public void Heal(int amount)
    {
        currentHeart += amount;

        if (currentHeart > maxHeart)
        {
            currentHeart = maxHeart;
        }
    }

    void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}