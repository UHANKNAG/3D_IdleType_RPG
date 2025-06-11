using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectObject collectData;
    private float curHP;

    private void Start()
    {
        if (collectData != null)
            curHP = collectData.hp.maxValue;
    }

    public void TakeDamage(float damage)
    {
        curHP -= damage;

        if (curHP <= 0)
        {
            RewardToPlayer();
            Destroy(gameObject);
        }
    }

    public void DealDamage()
    {
        // poisonDamage만큼 player에게 피해 주기
        PlayerMediator.Instance.playerCondition.hp.curValue -= collectData.poisonDamage;
    }
    
    private void RewardToPlayer()
    {
        PlayerMediator.Instance.playerStats.gold += collectData.rewardGold;
        PlayerMediator.Instance.playerStats.AddExp(collectData.rewardExp);
        PlayerMediator.Instance.playerInventory.AddItem(collectData.rewardItem);
        // Debug.Log($"{collectData.rewardItem} 아이템 획득");
    }
}
