using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity is waiting for turn
/// </summary>
public class PlayerWaitState : State
{
    public PlayerWaitState(Entity entity, EntityStateMachine stateMachine) : base(entity, stateMachine)
    {

    }

    public override IEnumerator Enter()
    {
        Debug.Log("Player has entered WaitState!");

        yield break;
    }

    public override IEnumerator Exit()
    {
        return base.Exit();
    }
}
