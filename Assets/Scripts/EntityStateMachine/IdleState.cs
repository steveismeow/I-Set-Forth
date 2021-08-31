using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player is deciding action to take; Unity has paused world
/// </summary>
public class IdleState : State
{
    public IdleState(Entity entity, EntityStateMachine stateMachine) : base(entity, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
