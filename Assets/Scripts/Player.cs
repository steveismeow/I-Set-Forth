using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public static Player Instance { get; private set; }

    #region State Variables
    public DecisionState decisionState { get; private set; }

    #endregion

    private void Start()
    {
        decisionState = new DecisionState(this, StateMachine);

    }

    private void Update()
    {
 

        if (myTurn)
        {
            //Temp: passes turn on spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EndOfTurnTrigger();
            }

        }
    }

    public override void StartTurn()
    {
        base.StartTurn();

        StateMachine.ChangeState(decisionState);

    }
}
