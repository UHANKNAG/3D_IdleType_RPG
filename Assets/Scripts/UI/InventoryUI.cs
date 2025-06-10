using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryScreen;
    public Button[] slots = new Button[9];
    public TextMeshProUGUI[] texts = new TextMeshProUGUI[9];
    public List<ItemObject> items;
    public PlayerInventory playerInventory;
    
    // Start is called before the first frame update
    void Start()
    {
        inventoryScreen.SetActive(false);

        for (int i = 0; i < slots.Length; i++)
        {
            GameObject buttonObject = GameObject.Find($"Button{i}");
            if (buttonObject != null)
            {
                slots[i] = buttonObject.GetComponent<Button>();
                texts[i] = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayInventoryItem()
    {
        if (playerInventory.items != null)
        {
            for (int i = 0; i < playerInventory.items.Count; i++)
            {
                slots[i].image.sprite = playerInventory.items[i].itemIcon;
                texts[i].text = playerInventory.items[i].quantity.ToString();
            }
        }
    }

    public void OpenInventory()
    {
        if (inventoryScreen.activeSelf)
        {
            inventoryScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            DisplayInventoryItem();
            inventoryScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
