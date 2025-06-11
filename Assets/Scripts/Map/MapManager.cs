using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    public Block curBlock;
    public Block nextBlock;
    public Block tempBlock;

    public int curWave = 1;
    public int curStage = 1;
    
    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        // 현재 Block에서 벗어나 있고, 다음 Block에 진입해 있으면
        if (curBlock.isPass && nextBlock.isNext)
        {
            // wave & stage 관리
            curWave++;
            if (curWave == 3)
            {
                curStage++;
                curWave = 0;
            }
            
            // 현재 block 위치 조정
            curBlock.transform.position += new Vector3(0f, 0f, 100f);
            
            // 현재 block과 다음 block 변경
            tempBlock = curBlock;
            curBlock = nextBlock;
            nextBlock = tempBlock;

            // bool값 세팅
            // 하지 않으면 block들이 끝도 없이 이동함
            curBlock.isPass = false;
            curBlock.isNext = true;
            nextBlock.isNext = false;
            nextBlock.isPass = true;
        }
    }
}
