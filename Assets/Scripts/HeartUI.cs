using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image[] hearts;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < playerHealth.currentHeart;
        }
    }
}