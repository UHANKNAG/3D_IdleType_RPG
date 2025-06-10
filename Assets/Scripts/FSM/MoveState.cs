using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public MoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.Animator.SetBool("Move", true);
    }

    public override void Update()
    {
        if (stateMachine.IsObstacleAhead())
        {
            stateMachine.ChangeState(new AttackState(stateMachine));
            return;
        }

        Vector3 move = stateMachine.transform.forward * stateMachine.moveSpeed * Time.deltaTime;
        stateMachine.Controller.Move(move);
    }

    public override void Exit()
    {
        stateMachine.Animator.SetBool("Move", false);
    }
}
