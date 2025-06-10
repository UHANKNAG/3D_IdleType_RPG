using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Button inventoryButton;
    public GameObject inventoryScreen;
    public Button[] slots = new Button[9];
    public List<ItemObject> items;
    
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
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayInventoryItem()
    {
        PlayerMediator.Instance.playerInventory.items
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
            inventoryScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
