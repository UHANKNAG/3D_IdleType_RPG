using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMediator : Singleton<PlayerMediator>
{
    public PlayerCondition playerCondition;
    public PlayerStats playerStats;

    protected override void Awake()
    {
        base.Awake();
        playerCondition = GetComponent<PlayerCondition>();
        playerStats = GetComponent<PlayerStats>();
    }
}
