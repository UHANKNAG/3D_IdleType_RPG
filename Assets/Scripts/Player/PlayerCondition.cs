using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public Condition hp;
    public Condition mp;

    private void Start()
    {
        hp.maxValue = PlayerMediator.Instance.playerStats.stats["HP"].value;
        mp.maxValue = PlayerMediator.Instance.playerStats.stats["MP"].value;

        hp.curValue = hp.maxValue;
        mp.curValue = mp.maxValue;
    }

    private void Update()
    {
        hp.maxValue = PlayerMediator.Instance.playerStats.stats["HP"].value;
        mp.maxValue = PlayerMediator.Instance.playerStats.stats["MP"].value;
        
        // Dead
        if (hp.curValue <= 0f)
        {
            Debug.Log("Player is Dead.");
        }
    }
}
