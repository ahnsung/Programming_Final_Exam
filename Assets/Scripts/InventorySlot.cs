using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemIcon;
    public int slotIndex;

    public void SetItem(ItemType itemType)
    {
        itemIcon.enabled = true;
    }

    public void ClearSlot()
    {
        itemIcon.enabled = false;
    }

    public void OnClickSlot()
    {
        InventoryManager.Instance.UseItem(slotIndex);
    }
}