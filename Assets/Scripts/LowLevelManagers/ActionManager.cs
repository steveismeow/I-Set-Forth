using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionManager : MonoBehaviour
{
    public void MoveInstantly(Vector3 gridPositionDestination)
    {

        this.transform.position = gridPositionDestination;

    }

    //public IEnumerator MoveTileByTile(Vector3 gridPositionDestination)
    //{
    //    //Get "path" from Pathfinding Script

    //    //foreach (Tile in "path" list) 

    //    //{
        
    //    //player.state = player.moveState;

    //    //Move to next tile

    //    //player.state = player.pause

    //    //yield return new WaitForSeconds(2f or animationLength);

    //    //}
    //}

    //Player Input or NPC AI

    //AP Management
    //Create Action classes
    //Create communication for AP economy
    //Tie that in to Entity Scripts and PlayerInput






}
