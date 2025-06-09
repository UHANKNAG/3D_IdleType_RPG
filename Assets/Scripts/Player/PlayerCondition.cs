using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public Condition hp;
    public Condition mp;

    private void Awake()
    {
        hp.maxValue = 100f; // 추후 player stat 값으로 변경할 것
        mp.maxValue = 100f; // ''

        hp.curValue = hp.maxValue;
        mp.curValue = mp.maxValue;
    }

    private void Update()
    {
        // Dead
        if (hp.curValue <= 0f)
        {
            Debug.Log("Player is Dead.");
        }
    }
}
