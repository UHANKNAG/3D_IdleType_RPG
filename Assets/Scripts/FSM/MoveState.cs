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
        if (stateMachine.IsTargetAhead())
        {
            stateMachine.ChangeState(new AttackState(stateMachine));
            return;
        }

        // 입력이 따로 없어도 자동 전진
        Vector3 move = stateMachine.transform.forward * stateMachine.moveSpeed * Time.deltaTime;
        stateMachine.Controller.Move(move);
    }

    public override void Exit()
    {
        stateMachine.Animator.SetBool("Move", false);
    }
}
