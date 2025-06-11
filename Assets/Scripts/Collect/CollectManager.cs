using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// 생성 관련
public class CollectManager : Singleton<CollectManager>
{
    public List<Collectable> collectPrefabs;
    public int maxCollect = 5;
    public float spacing = 10f;
    public Transform startPosition;
    
    private List<GameObject> activeCollects = new List<GameObject>();
    private float lastZPosition;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        
        lastZPosition = startPosition.position.z;

        for (int i = 0; i < maxCollect; i++)
        {
            SpawnNextCollect();
        }
    }
    
    public void OnCollectDestroy(GameObject collect)
    {
        activeCollects.Remove(collect);
        Destroy(collect);
        SpawnNextCollect();
    }
    
    private void SpawnNextCollect()
    {
        Collectable randomPrefab = collectPrefabs[Random.Range(0, collectPrefabs.Count)];
        Vector3 spawnPos = new Vector3(0, 0, lastZPosition + spacing);

        GameObject collect = Instantiate(randomPrefab.collectData.prefab, spawnPos, Quaternion.identity);
        activeCollects.Add(collect);
        lastZPosition += spacing;
    }
}
