using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity
{
    public NPCTurnState npcTurnState { get; private set; }
    public NPCWaitState npcWaitState { get; private set; }

    private void Awake()
    {
        npcTurnState = new NPCTurnState(this, StateMachine);
        npcWaitState = new NPCWaitState(this, StateMachine);

    }

    private void Start()
    {



        StateMachine.InitializeState(npcWaitState);
    }
    public override void StartTurn()
    {
        base.StartTurn();

        EndOfTurnTrigger();
    }
}
