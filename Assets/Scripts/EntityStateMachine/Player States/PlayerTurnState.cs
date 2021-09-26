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
        //yield return new WaitForSeconds(10f);

        entity.GetComponent<Player>().turnInputManager.enabled = true;

        yield return new WaitUntil(() => entity.GetExitTurnState());

        //player.turnInputManager.enabled = false;


        Exit();

    }

    public override IEnumerator Exit()
    {
        //REFACTORING: We can bring this functionality to the base State class and the base Entity class
        entity.EndOfTurnTrigger();

        return base.Exit();
    }

}
