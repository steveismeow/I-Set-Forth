using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Translating player to designated Tile
/// </summary>
public class MoveState : State
{
    public MoveState(Entity entity, EntityStateMachine stateMachine) : base(entity, stateMachine)
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
