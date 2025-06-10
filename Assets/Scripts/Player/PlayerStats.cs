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
    
    // hp, mp, attack, defence는 stats으로
    public Dictionary<string, Stat> stats;

    private void Awake()
    {
        level = 1;
        exp = 0f;
        expToNextLevel = 10f;
        gold = 0;
        
        stats = new Dictionary<string, Stat>
        {
            { "HP", new Stat("HP", 100f) },
            { "MP", new Stat("MP", 50f) },
            { "Attack", new Stat("Attack", 10f) },
            { "Defence", new Stat("Defence", 5f) },
        };
    }

    public void AddExp(float amount)
    {
        exp += amount;
        if (exp >= expToNextLevel)
        {
            exp = 0f;
            LevelUP();
        }
    }
    
    void LevelUP()
    {
        level++;
        expToNextLevel *= 2f;
        // levelup 시 체력 회복 stats["HP"].
    }

}
