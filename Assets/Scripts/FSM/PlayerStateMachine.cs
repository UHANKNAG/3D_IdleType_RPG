using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public State idleState { get; private set; }
    public State moveState { get; private set; }
    public State attackState { get; private set; }

    private State curState;

    private CharacterController controller;

    // 감지할 거리
    public float detectRange = 2f;

    // 감지할 대상의 Layer
    public LayerMask targetLayer;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        idleState = new IdleState(this, controller);
        moveState = new MoveState(this, controller);
        attackState = new AttackState(this, controller);
        
        ChangeState(idleState);
    }

    private void Update()
    {
        curState?.Update();
    }

    public void ChangeState(State newState)
    {
        curState?.Exit();
        curState = newState;
        curState?.Enter();
    }
    
    // Raycast로 전방 대상 감지 (추후 다른 곳으로 뺄 수 있으면 빼는 게 좋을 듯)
    public bool DetectTarget()
    {
        // 전방으로 레이 발사하여 LayerMask에 포함된 오브젝트 감지
        return Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.forward, detectRange, targetLayer);
    }
}
