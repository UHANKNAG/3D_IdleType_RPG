using UnityEngine;

public class AttackState : State
{
    private float attackCooldown = 1f;
    private float lastAttackTime;

    public AttackState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        stateMachine.Animator.SetTrigger("Attack");
        lastAttackTime = Time.time;
    }

    public override void Update()
    {
        if (stateMachine.IsObstacleAhead())
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                PerformAttack();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            stateMachine.ChangeState(new MoveState(stateMachine));
        }
    }

    private void PerformAttack()
    {
        Debug.Log("적을 공격합니다.");
        stateMachine.Animator.SetTrigger("Attack");

        // TODO: 적에게 데미지를 주는 로직이 있다면 여기에 추가
        // 예: stateMachine.Target?.GetComponent<Enemy>()?.TakeDamage(10);
    }
}