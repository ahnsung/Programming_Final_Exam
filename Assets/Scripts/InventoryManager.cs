using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("Player")]
    public PlayerHealth playerHealth;
    public PlayerController playerController;

    [Header("UI")]
    public TMP_Text potionCountText;
    public TMP_Text skillCountText;

    private int potionCount = 0;
    private int skillCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public bool AddItem(ItemType itemType)
    {
        if (itemType == ItemType.Potion)
        {
            potionCount++;
        }
        else if (itemType == ItemType.Skill)
        {
            skillCount++;
        }

        UpdateUI();
        return true;
    }

    public void UsePotion()
    {
        if (potionCount <= 0)
            return;

        if (playerHealth.currentHeart >= playerHealth.maxHeart)
            return;

        potionCount--;
        playerHealth.Heal(1);
        UpdateUI();
    }

    public void UseSkill()
    {
        if (skillCount <= 0)
            return;

        skillCount--;

        if (playerController != null)
        {
            playerController.ActivateRapidFire(5f);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (potionCountText != null)
            potionCountText.text = "x " + potionCount;

        if (skillCountText != null)
            skillCountText.text = "x " + skillCount;
    }
}