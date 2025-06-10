using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameUI gameUI;
    public ConditionUI conditionUI;
    public InventoryUI inventoryUI;
    
    // or PlayerUI, GoldUI, StageUI?
    
    protected override void Awake()
    {
        base.Awake();
        gameUI = GetComponentInChildren<GameUI>();
        conditionUI = GetComponentInChildren<ConditionUI>();
        inventoryUI = GetComponentInChildren<InventoryUI>();
    }
}
