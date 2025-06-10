using System.Collections;
using UnityEngine;

public class AttackState : State
{
    private float attackCooldown = 2f;
    private Coroutine attackCoroutine;
    private LayerMask targetLayer;

    public AttackState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        attackCoroutine = stateMachine.StartCoroutine(AttackLoop());
    }

    public override void Update()
    {
        // 매 프레임마다 적 존재 여부 확인
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
            yield return new WaitForSeconds(attackCooldown);
        }
    }

    private void PerformAttack()
    {
        stateMachine.Animator.SetTrigger("Attack");

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