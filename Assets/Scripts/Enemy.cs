using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public override void StartTurn()
    {
        base.StartTurn();

        EndOfTurnTrigger();
    }
}
