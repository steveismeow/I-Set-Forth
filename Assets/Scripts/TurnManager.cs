using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private EntityManager entityManager; 

    private List<GameObject> TurnOrderList = new List<GameObject>();
    private List<Entity> ActiveEntities = new List<Entity>();


    // Start is called before the first frame update
    void Start()
    {
        //Add Player Object
        FilterActiveEntities(entityManager.GetEntityList());
        SortActiveEntities();
    }

    // Update is called once per frame
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


}
