using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public PlayerHealth playerHealth;
    public List<ItemType> items = new List<ItemType>();

    public InventorySlot[] slots;

    private void Awake()
    {
        Instance = this;
    }

    public bool AddItem(ItemType item)
    {
        if (items.Count >= slots.Length)
        {
            Debug.Log("인벤토리가 가득 찼습니다.");
            return false;
        }

        items.Add(item);
        UpdateUI();

        Debug.Log(item + " 획득");
        return true;
    }

    public void UseItem(int index)
    {
        if (index < 0 || index >= items.Count)
            return;

        ItemType item = items[index];

        if (item == ItemType.Potion)
        {
            playerHealth.Heal(1);
            Debug.Log("포션 사용: 체력 1 회복");
        }
        else if (item == ItemType.Skill)
        {
            Debug.Log("스킬 아이템 사용");
        }

        items.RemoveAt(index);
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
                slots[i].SetItem(items[i]);
            else
                slots[i].ClearSlot();
        }
    }
}