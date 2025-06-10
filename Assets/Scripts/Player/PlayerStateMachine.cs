using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public State CurrentState { get; private set; }
    
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }
    
    public float moveSpeed = 2f;
    public float detectDistance = 1f;
    public LayerMask targetLayer;

    private RaycastHit targetHit;

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        ChangeState(new MoveState(this));
    }

    private void Update()
    {
        CurrentState?.Update();
    }

    public void ChangeState(State newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public bool IsTargetAhead()
    {
        Vector3 origin = transform.position + Vector3.up * 0.5f;
        Vector3 direction = transform.forward;
        if (Physics.Raycast(origin, direction, out targetHit, detectDistance, targetLayer))
        {
            return true;
        }

        // 감지 실패
        return false;
    }

    public RaycastHit GetTarget()
    {
        return targetHit;
    }
}