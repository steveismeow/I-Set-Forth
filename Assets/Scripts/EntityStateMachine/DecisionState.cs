using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player is deciding action to take; Unity has paused world
/// </summary>
public class DecisionState : State
{
    public DecisionState(Entity entity, EntityStateMachine stateMachine) : base(entity, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Player has entered Decision State!");

        //activate the UI elements for selecting actions
    }

    public override void Exit()
    {
        base.Exit();

        //deactivate the UI elements for selecting actions
    }
}
