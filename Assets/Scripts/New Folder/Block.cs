using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Block : MonoBehaviour
{
    public bool isPass = false;
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
