using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public InventoryUI inventoryUI;

    private void Start()
    {
        inventoryUI = UIManager.Instance.inventoryUI;
    }

    // 선택 아이템 사용 처리 로직
    public void SelectItem()
    {
        Sprite clickedSprite = GetComponent<Image>().sprite;
        
        if (inventoryUI.playerInventory.items != null)
        {
            foreach (var i in inventoryUI.playerInventory.items)
            {
                if (i != null && i.itemIcon == clickedSprite)
                {
                    inventoryUI.playerInventory.UseItem(i);
                    Debug.Log($"Used item: {i.itemName}");
                    // 아이템 사용 후 Inventory 창 다시 Load
                    inventoryUI.DisplayInventoryItem();
                    return;
                }
            }
        }
    }
}
