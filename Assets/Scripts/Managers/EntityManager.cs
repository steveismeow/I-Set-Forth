using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    //On startup spawn an entity at gridPosition 0,0

    public GameObject playerPrefab;

    public TileManager tileManager;

    private List<GameObject> entities = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //Spawn the player at 0,0
        SpawnEntity(playerPrefab, new Vector3Int(0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SpawnEntity(GameObject entity, Vector3Int gridPosition)
    {
        Vector3 location = tileManager.GetTruePosition(gridPosition);

        GameObject entityObject = Instantiate(entity, location, Quaternion.identity);

        //Add to entity list
        entities.Add(entityObject);
    }

    public List<GameObject> GetEntityList() => entities;

}
