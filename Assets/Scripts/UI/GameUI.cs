using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    // Exp UI
    [SerializeField] private float exp;
    public Image expBar;
    
    // Level UI
    [SerializeField] private int level;
    public TextMeshProUGUI lvText;
    
    // Gold UI
    [SerializeField] private int gold;
    public TextMeshProUGUI goldText;
    
    // Stage UI
    [SerializeField] private int stageNum;
    public TextMeshProUGUI stageText;

    private void Update()
    {
        exp = PlayerMediator.Instance.playerStats.exp;
        expBar.fillAmount = GetExpPercentage();
        
        gold = PlayerMediator.Instance.playerStats.gold;
        goldText.text = $"{gold}";

        level = PlayerMediator.Instance.playerStats.level;
        lvText.text = $"{level}";
    }

    float GetExpPercentage()
    {
        float curExp = exp;
        float maxExp = PlayerMediator.Instance.playerStats.expToNextLevel;
        return curExp / maxExp;
    }
}
