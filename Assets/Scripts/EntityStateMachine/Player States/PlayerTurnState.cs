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
        yield return new WaitForSeconds(10f);
    }

    public override IEnumerator Exit()
    {
        return base.Exit();
    }

}
