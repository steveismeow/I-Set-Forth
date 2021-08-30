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

    private Player player;

    private bool entityIsTakingItsTurn;
    private Coroutine executingTurnCoroutine;


    void Start()
    {
        player = entityManager.Player;
        TurnOrderReset();

        //Tell entity at TurnOrderList[0] to take its turn
        //entity.currentState = BatterUp!(this is a joke, but it may be worthwhile to utilize a simple entity state machine,
        //in which the entity's turn coroutine can begin or whatever)
    }

    void Update()
    {


    }

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

    private void SortActiveEntities()
    {
        ActiveEntities.Sort((x, y) => x.level.CompareTo(y.level));
    }

    private void PopulateTurnOrderList()
    {
        TurnOrderList = ActiveEntities;

        TurnOrderList.Insert(0, player);
    }

    //public bool EndOfTurnTrigger() => entityIsTakingItsTurn = false;

    private IEnumerator ExecutingTurns()
    {
        Entity entity;

        while (TurnOrderList.Count != 0)
        {
            entity = TurnOrderList[0];

            entity.StartTurn();

            print("Player StartTurn() called");

            yield return new WaitForEndOfFrame();

            //THIS DOESNT WORK--------------------------------------------------------
            //yield return new WaitUntil(() => entity.GetEndOfTurnBool());

            //THIS DOESNT WORK--------------------------------------------------------
            //entityIsTakingItsTurn = true;

            //while (entityIsTakingItsTurn)
            //{
            //    if (entity.GetEndOfTurnBool() == true)
            //    {
            //        entityIsTakingItsTurn = false;
            //        print("entity has finished, entityistakingitsturn = " + entityIsTakingItsTurn);

            //        yield return null;
            //    }
            //}

            print("Turn passed");

            TurnOrderList.Remove(entity);
        }

        TurnOrderReset();

        //TODO: End of round stuff
        //Incremenmt World Clock, Update Gameboard, Check Level Progression, Check New Spawns, Reset AP

    }


    private void TurnOrderReset()
    {
        FilterActiveEntities(entityManager.GetEntityList());
        SortActiveEntities();
        PopulateTurnOrderList();

        executingTurnCoroutine = StartCoroutine(ExecutingTurns());
    }


}
