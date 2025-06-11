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
        // 마지막 포지션 초기화
        lastZPosition = startPosition.position.z;
        
        // maxCollect 개수만큼 Spawn
        for (int i = 0; i < maxCollect; i++)
        {
            SpawnNextCollect();
        }
    }
    
    // 파괴 로직
    public void OnCollectDestroy(GameObject collect)
    {
        activeCollects.Remove(collect);
        Destroy(collect);
        SpawnNextCollect();
    }
    
    // 생성 로직
    private void SpawnNextCollect()
    {
        // 프리팹 중에서 랜덤 선택
        Collectable randomPrefab = collectPrefabs[Random.Range(0, collectPrefabs.Count)];
        // 스폰 위치 세팅
        Vector3 spawnPos = new Vector3(0, 0, lastZPosition + spacing);

        // 생성
        GameObject collect = Instantiate(randomPrefab.collectData.prefab, spawnPos, Quaternion.identity);
        // 리스트 관리
        activeCollects.Add(collect);
        // 다음 스폰을 위해 위치 조정
        lastZPosition += spacing;
    }
}
