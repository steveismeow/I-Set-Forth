using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionManager : MonoBehaviour
{
    public void MoveInstantly(Vector3 gridPositionDestination)
    {

        this.transform.position = gridPositionDestination;

    }
}
