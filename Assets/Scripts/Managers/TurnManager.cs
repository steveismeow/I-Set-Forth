using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private EntityManager entityManager; 

    private List<GameObject> TurnOrderList = new List<GameObject>();
    private List<Entity> ActiveEntities = new List<Entity>();


    void Start()
    {
        FilterActiveEntities(entityManager.GetEntityList());
        SortActiveEntities();
        PopulateTurnOrderList();

        //Tell entity at TurnOrderList[0] to take its turn
        //entity.currentState = BatterUp!(this is a joke, but it may be worthwhile to utilize a simple entity state machine,
        //in which the entity's turn coroutine can begin or whatever)
    }

    void Update()
    {
        
    }

    private void FilterActiveEntities(List<GameObject> entityList)
    {
        //foreach (GameObject entity in entityList)
        //{
        //    //if entity is within active radius
        //    if (pathfindingManager.CheckIfActive(entity.transform))
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
        foreach(Entity entity in ActiveEntities)
        {
            //if entity is the Player
            if (entity.name == "Player")
            {
                //Insert at index 0
                TurnOrderList.Insert(0, entity.gameObject);
            }
            else
            {
                //add to bottom of the list
                TurnOrderList.Add(entity.gameObject);
            }
        }
    }


}
