using System.Collections;
using UnityEngine;

public class AttackState : State
{
    private Coroutine attackCoroutine;
    private LayerMask targetLayer;
    
    public AttackState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        attackCoroutine = stateMachine.StartCoroutine(AttackLoop());
    }

    public override void Update()
    {
        // 적 존재 여부 확인
        if (!stateMachine.IsTargetAhead())
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
            yield return new WaitForSeconds(PlayerMediator.Instance.playerStats.stats["AttackCoolDown"].value);
        }
    }

    private void PerformAttack()
    {
        stateMachine.Animator.SetTrigger("Attack");

        // Attack 타겟과의 상호작용
        RaycastHit hit = stateMachine.GetTarget();

        if (hit.collider != null && hit.collider.CompareTag("Collect"))
        {
            Collectable collectObject = hit.collider.GetComponent<Collectable>();
            if (collectObject != null)
            {
                collectObject.TakeDamage(PlayerMediator.Instance.playerStats.stats["Attack"].value);
                collectObject.DealDamage();
            }
        }
    }
}