using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectData", menuName = "CreateCollectData/CollectData")]
public class CollectObject : ScriptableObject
{
    public Condition hp;
    public float poisonDamage;
    public int rewardGold;
    public float rewardExp;

    public GameObject prefab;
}
