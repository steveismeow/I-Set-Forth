using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateMachine
{
    public State currentState { get; private set; }

    public void InitializeState(State state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void ChangeState(State state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
}
