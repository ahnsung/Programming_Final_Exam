using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHeart = 5;
    public int currentHeart;

    void Start()
    {
        currentHeart = maxHeart;
    }

    public void TakeDamage(int damage)
    {
        currentHeart -= damage;

        if (currentHeart <= 0)
        {
            currentHeart = 0;
            GameOver();
        }

        Debug.Log("현재 체력: " + currentHeart);
    }

    public void Heal(int amount)
    {
        currentHeart += amount;

        if (currentHeart > maxHeart)
        {
            currentHeart = maxHeart;
        }

        Debug.Log("현재 체력: " + currentHeart);
    }

    void GameOver()
    {
        Debug.Log("게임 오버");
        Time.timeScale = 0f;
    }
}