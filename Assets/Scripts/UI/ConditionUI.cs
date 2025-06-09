using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionUI : MonoBehaviour
{
    [SerializeField] private Condition hp;
    [SerializeField] private Condition mp;
    public Image hpBar;
    public Image mpBar;
    
    void Start()
    {
        hp = PlayerMediator.Instance.playerCondition.hp;
        mp = PlayerMediator.Instance.playerCondition.mp;
    }
    
    void Update()
    {
        hpBar.fillAmount = hp.curValue / hp.maxValue;
        mpBar.fillAmount = mp.curValue / mp.maxValue;
    }
}
