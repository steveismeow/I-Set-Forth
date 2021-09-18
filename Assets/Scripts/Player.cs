using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public static Player Instance { get; private set; }

    #region State Variables
    public PlayerTurnState playerTurnState { get; private set; }
    public PlayerWaitState playerWaitState { get; private set; }


    #endregion


    private void Start()
    {
        playerTurnState = new PlayerTurnState(this, StateMachine);
        playerWaitState = new PlayerWaitState(this, StateMachine);


        StateMachine.InitializeState(playerWaitState);

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

        ////Testing MoveInstantly() action
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector3Int gridPosition = tileManager.tileMap.WorldToCell(mousePosition);



        //    actionManager.MoveInstantly(tileManager.GetTruePosition(gridPosition));

        //}
    }

    /// <summary>
    /// Functions called at turn start
    /// </summary>
    public override void StartTurn()
    {
        base.StartTurn();

        StateMachine.ChangeState(playerTurnState);

    }
}

