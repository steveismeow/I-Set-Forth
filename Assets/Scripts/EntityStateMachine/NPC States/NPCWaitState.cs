using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity is waiting for turn
/// </summary>
public class NPCWaitState : State
{
    public NPCWaitState(Entity entity, EntityStateMachine stateMachine) : base(entity, stateMachine)
    {

    }

    public override IEnumerator Enter()
    {
        yield return new WaitForSeconds(2f);
    }

    public override IEnumerator Exit()
    {
        return base.Exit();
    }
}
