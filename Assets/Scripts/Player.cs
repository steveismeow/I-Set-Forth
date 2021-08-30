using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        print(endOfTurn);
        
        if (!endOfTurn)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                print("endofturntrigger");
                EndOfTurnTrigger();
            }

        }
    }


    public override void StartTurn()
    {
        base.StartTurn();

    }

    public override bool EndOfTurnTrigger()
    {
        return base.EndOfTurnTrigger();
    }

    public override bool GetEndOfTurnBool()
    {
        return base.GetEndOfTurnBool();
    }
}
