using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player is deciding action to take; Unity has paused world
/// </summary>
public class PlayerTurnState : State
{
    public PlayerTurnState(Entity entity, EntityStateMachine stateMachine) : base(entity, stateMachine)
    {
    }

    public override IEnumerator Enter()
    {
        return base.Enter();
    }

    public override IEnumerator Exit()
    {
        return base.Exit();
    }
}
