using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.Animator.SetBool("Idle", true);
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        stateMachine.Animator.SetBool("Idle", false);
    }

    
}
