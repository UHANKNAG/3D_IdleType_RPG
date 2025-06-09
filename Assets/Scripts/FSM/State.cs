using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected PlayerStateMachine stateMachine;
    protected CharacterController controller;

    public State(PlayerStateMachine stateMachine, CharacterController controller)
    {
        this.stateMachine = stateMachine;
        this.controller = controller;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
