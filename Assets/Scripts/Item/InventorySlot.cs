using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public InventoryUI inventoryUI;

    private void Start()
    {
        inventoryUI = UIManager.Instance.inventoryUI;
    }

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
                    return;
                }
            }
        }
    }
}
