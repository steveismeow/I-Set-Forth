using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity is waiting for turn
/// </summary>
public class WaitState : State
{
    public WaitState(Entity entity, EntityStateMachine stateMachine) : base(entity, stateMachine)
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
