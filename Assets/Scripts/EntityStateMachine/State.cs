using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Entity entity;
    protected EntityStateMachine stateMachine;

    public State(Entity entity, EntityStateMachine stateMachine)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
    }


    public virtual IEnumerator Enter()
    {

        yield break;
    }

    public virtual IEnumerator Exit()
    {
        yield break;
    }

    public override string ToString()
    {
        return this.GetType().Name.ToString();
    }


}
