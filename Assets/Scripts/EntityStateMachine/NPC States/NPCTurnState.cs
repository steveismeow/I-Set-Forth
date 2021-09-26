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
        //Activate AI
        entity.GetComponent<NPCAI>().enabled = true;

        yield return new WaitUntil(() => entity.GetExitTurnState());

        Exit();
    }

    public override IEnumerator Exit()
    {
        //REFACTORING: We can bring this functionality to the base State class and the base Entity class
        entity.EndOfTurnTrigger();

        return base.Exit();
    }
}
