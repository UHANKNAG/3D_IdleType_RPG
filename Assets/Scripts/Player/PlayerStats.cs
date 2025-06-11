using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int level;
    public float exp;
    public float expToNextLevel;

    public int gold;
    
    // hp, mp, attack, defence, cooltime은 stats으로
    public Dictionary<string, Stat> stats;

    private void Awake()
    {
        level = 1;
        exp = 0f;
        expToNextLevel = 50f;
        gold = 0;
        
        stats = new Dictionary<string, Stat>
        {
            { "HP", new Stat("HP", 100f) },
            { "MP", new Stat("MP", 50f) },
            { "Attack", new Stat("Attack", 10f) },
            { "Defence", new Stat("Defence", 5f) },
            { "AttackCoolDown", new Stat("AttackCoolDown", 2f)}
        };
    }

    // 경험치 추가 로직
    public void AddExp(float amount)
    {
        exp += amount;
        if (exp >= expToNextLevel)
        {
            exp -= expToNextLevel;
            LevelUP();
        }
    }
    
    // 레벨업 및 스탯 증가 로직
    void LevelUP()
    {
        level++;
        expToNextLevel *= 2f;
        stats["HP"].value += 50f;
        stats["MP"].value += 10f;
        // 공격 받는 중에 레벨업 하게 되면 순서가 꼬여 제대로 반영되지 않을 수 있어 약간의 딜레이를 줬다
        Invoke("updateStat", 0.1f);
    }
    
    void updateStat()
    {
        PlayerMediator.Instance.playerCondition.hp.curValue 
            = PlayerMediator.Instance.playerCondition.hp.maxValue;
    }

}
