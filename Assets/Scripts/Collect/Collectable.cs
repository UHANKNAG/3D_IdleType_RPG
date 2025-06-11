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

    // Player에게 공격 받고 남은 체력을 확인하여 Destroy 처리
    public void TakeDamage(float damage)
    {
        curHP -= damage;

        if (curHP <= 0)
        {
            RewardToPlayer();
            CollectManager.Instance.OnCollectDestroy(gameObject);
        }
    }

    // Player에게 일정 공격 처리
    public void DealDamage()
    {
        PlayerMediator.Instance.playerCondition.hp.curValue -= collectData.poisonDamage;
    }
    
    // 처치 시 Player에게 보상 지급
    private void RewardToPlayer()
    {
        PlayerMediator.Instance.playerStats.gold += collectData.rewardGold;
        PlayerMediator.Instance.playerStats.AddExp(collectData.rewardExp);
        PlayerMediator.Instance.playerInventory.AddItem(collectData.rewardItem);
    }
}
