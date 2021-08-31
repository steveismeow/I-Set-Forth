using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Entity entity;
    protected EntityStateMachine stateMachine;

    public State(Entity entity, EntityStateMachine stateMachine)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
    }


    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

}
