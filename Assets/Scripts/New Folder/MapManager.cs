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
    
    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        if (curBlock.isPass && nextBlock.isNext)
        {
            curBlock.transform.position += new Vector3(0f, 0f, 100f);
            
            tempBlock = curBlock;
            curBlock = nextBlock;
            nextBlock = tempBlock;

            curBlock.isPass = false;
            curBlock.isNext = true;
            nextBlock.isNext = false;
            nextBlock.isPass = true;
        }
    }
}
