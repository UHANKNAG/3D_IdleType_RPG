using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "CreateItemData/ItemData")]
public class ItemObject : ScriptableObject
{
    public string itemName;
    public string buffName;
    public float buffAmount;
    public float duration;
    public Sprite itemIcon;

    public int quantity;
}
