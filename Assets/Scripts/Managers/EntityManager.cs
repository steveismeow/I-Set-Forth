using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    //On startup spawn an entity at gridPosition 0,0

    public GameObject playerPrefab;

    //Test
    public GameObject enemyPrefab;

    public Player Player;

    public TileManager tileManager;

    [SerializeField]
    private List<Entity> entities = new List<Entity>();

    // Start is called before the first frame update
    void Awake()
    {
        //Spawn the player at 0,0
        SpawnPlayer(playerPrefab, new Vector3Int(0, 0, 0));

        SpawnEntity(enemyPrefab, new Vector3Int(-1, 0, 0));

    }


    private void SpawnPlayer(GameObject player, Vector3Int gridPosition)
    {
        Vector3 location = tileManager.GetTruePosition(gridPosition);

        GameObject entityObject = Instantiate(player, location, Quaternion.identity);

        Player = entityObject.GetComponent<Player>();
    }

    private void SpawnEntity(GameObject entity, Vector3Int gridPosition)
    {
        Vector3 location = tileManager.GetTruePosition(gridPosition);

        GameObject entityObject = Instantiate(entity, location, Quaternion.identity);

        //Add to entity list
        entities.Add(entityObject.GetComponent<Entity>());
    }

    public List<Entity> GetEntityList() => entities;
    public Player GetPlayer() => Player;

}
