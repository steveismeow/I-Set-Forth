using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public static Player Instance { get; private set; }
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

    //Gets


    //Leaving here in case we want to modify theses, otherwise these base functions are already defined in Entity.
    //public override void StartTurn()
    //{
    //    base.StartTurn();
    //}

    //public override void EndOfTurnTrigger()
    //{
    //    base.EndOfTurnTrigger();
    //}

    //public override bool GetTurnStatus()
    //{
    //    return base.GetTurnStatus();
    //}
}
