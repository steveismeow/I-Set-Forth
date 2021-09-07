using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateMachine : MonoBehaviour
{

    public State currentState { get; private set; }

    public void InitializeState(State state)
    {
        currentState = state;
        print(state);
        StartCoroutine(currentState.Enter());
    }

    public void ChangeState(State state)
    {
        StartCoroutine(currentState.Exit());
        currentState = state;
        print(state);
        StartCoroutine(currentState.Enter());
    }
}
