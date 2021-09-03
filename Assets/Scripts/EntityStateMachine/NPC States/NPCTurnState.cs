using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity is taking turn
/// </summary>
public class NPCTurnState : State
{
    public NPCTurnState(Entity entity, EntityStateMachine stateMachine) : base(entity, stateMachine)
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
