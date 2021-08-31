using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private EntityManager entityManager; 

    [SerializeField]
    private List<Entity> TurnOrderList = new List<Entity>();

    [SerializeField]
    private List<Entity> ActiveEntities = new List<Entity>();

    private bool entityIsTakingItsTurn;
    private Coroutine executingTurnCoroutine;


    void Start()
    {
        TurnOrderReset();

        //Tell entity at TurnOrderList[0] to take its turn
        //entity.currentState = BatterUp!(this is a joke, but it may be worthwhile to utilize a simple entity state machine,
        //in which the entity's turn coroutine can begin or whatever)
    }

    /// <summary>
    /// Filters the list of entities by "active" status.
    /// </summary>
    /// <param name="entityList">list of all entities on the gameboard</param>
    private void FilterActiveEntities(List<Entity> entityList)
    {
        ActiveEntities = entityManager.GetEntityList();

        //foreach (GameObject entity in entityList)
        //{
        //    //if entity is within active radius
        //    if (pathfindingManager.CheckIfActive(entity.gameObject.transform))
        //    {

        //        ActiveEntities.Add(entity.GetComponent<Entity>());
        //    }
        //}

    }

    /// <summary>
    /// Sorts active entity list by their level.
    /// </summary>
    private void SortActiveEntities()
    {
        ActiveEntities.Sort((x, y) => x.level.CompareTo(y.level));
    }
    
    /// <summary>
    /// Adds all entities to the TurnOrderList. Player goes first and then all remaining entities.
    /// </summary>
    private void PopulateTurnOrderList()
    {
        //Add player to the top of the initiative.
        TurnOrderList.Add(entityManager.GetPlayer());
        //Add all active entities to the turn order.
        TurnOrderList.AddRange(ActiveEntities);

        //TurnOrderList = ActiveEntities;
        //TurnOrderList.Insert(0, entityManager.GetPlayer());
    }


    /// <summary>
    /// Coroutine to handle turn order. Iterates through the entire TurnOrderList and yields until the entity turn has complete and then removes entity from the turn order.
    /// </summary>
    /// <returns>Ienumerator coroutine</returns>
    private IEnumerator ExecutingTurns()
    {

        foreach (Entity entity in TurnOrderList){
            // Gets next entity up in the turnorder

            //Sets endofturn
            entity.StartTurn();

            yield return new WaitWhile(()=>entity.GetTurnStatus());
        }

        TurnOrderReset();

        //TODO: End of round stuff
        //Incremenmt World Clock, Update Gameboard, Check Level Progression, Check New Spawns, Reset AP

    }

    /// <summary>
    /// Runs all functions associated with repopulating turn order with entities and running turn coroutines.
    /// </summary>
    private void TurnOrderReset()
    {
        FilterActiveEntities(entityManager.GetEntityList());
        SortActiveEntities();
        PopulateTurnOrderList();
        StartCoroutine(ExecutingTurns());
    }


}
