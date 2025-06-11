using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Block : MonoBehaviour
{
    // 현재 Block에서 벗어나 있는지 확인할 isPass
    public bool isPass = false;
    // 다음 Block에 진입했는지 확인할 isNext
    public bool isNext = false;

    private void OnTriggerEnter(Collider other)
    {
        isPass = false;
    }

    private void OnTriggerStay(Collider other)
    {
        isNext = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            isPass = true;
        }
    }
    
}
