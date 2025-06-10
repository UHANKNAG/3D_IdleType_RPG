using System.Collections;
using UnityEngine;

public class AttackState : State
{
    private float attackCooldown = 2f;
    private Coroutine attackCoroutine;

    public AttackState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        attackCoroutine = stateMachine.StartCoroutine(AttackLoop());
    }

    public override void Update()
    {
        // 매 프레임마다 적 존재 여부 확인
        if (!stateMachine.IsObstacleAhead())
        {
            stateMachine.ChangeState(new MoveState(stateMachine));
        }
    }

    public override void Exit()
    {
        if (attackCoroutine != null)
        {
            stateMachine.StopCoroutine(attackCoroutine);
        }
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            PerformAttack();
            yield return new WaitForSeconds(attackCooldown);
        }
    }

    private void PerformAttack()
    {
        Debug.Log("적을 공격합니다.");
        stateMachine.Animator.SetTrigger("Attack");

        // 데미지 처리
    }
}