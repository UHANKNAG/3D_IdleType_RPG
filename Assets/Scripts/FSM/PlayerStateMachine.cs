using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public State CurrentState { get; private set; }
    
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }
    
    public float moveSpeed = 2f;
    public float detectDistance = 1f;
    public LayerMask targetLayer;

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

    public bool IsObstacleAhead()
    {
        Vector3 origin = transform.position + Vector3.up * 0.5f; // 시야 약간 위에서
        Vector3 direction = transform.forward;
        return Physics.Raycast(origin, direction, detectDistance, targetLayer);
    }
}