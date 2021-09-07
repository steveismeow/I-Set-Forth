using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity
{
    public NPCTurnState npcTurnState { get; private set; }
    public NPCWaitState npcWaitState { get; private set; }

    private void Start()
    {

        npcTurnState = new NPCTurnState(this, StateMachine);
        npcWaitState = new NPCWaitState(this, StateMachine);


        StateMachine.InitializeState(npcWaitState);
    }
    public override void StartTurn()
    {
        base.StartTurn();

        StateMachine.ChangeState(npcTurnState);

        //TEST: Instantly ends turn
        EndOfTurnTrigger();
    }
}
