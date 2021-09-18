using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the TileInventory game object, which stores the draggable tile objects that can be dropped in the world to generate Tiles
/// </summary>
public class TileInventoryManager : MonoBehaviour
{
    //We can hardcode a List with any and all possible TileUiObjects. Which wouldn't be *too* tedious,
    //we could create a dictionary to manage these references if we need to. 

    //Alternatively, and, depending on how we want to store the player inventory information, 
    //we could instead pull that information from the player's data, then generate these objects on the fly. That sounds kinda hard though idk!
    //Anyway, we're gonna jank it with option 1 for now. 
    [SerializeField]
    private Camera uiCamera;

    public TileManager tileManager;

    [SerializeField]
    private GameObject TileStackObject;

    [SerializeField]
    private List<GameObject> TileUIObjects = new List<GameObject>();

    private List<GameObject> listWorkspace = new List<GameObject>();

    private int forestTiles = 2;
    private int mountainTiles = 4;


    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the Player

        //TEST: Generate tileobjects from the list, create a certain number of each
        PopulateInventory();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void EvaluatePlayerInventoryData()
    {
        //read in the player inventory data
    }

    private void PopulateInventory()
    {
        //

        //This thing needs to have a reference to the TileManager

        //and have a function that generates TileUIObjects. This function will set the new TileUIObject's TileManager reference to the TileManager

        //for each tile in the player's inventory (Maybe the inventory is a list of strings and a corresponding int value of how many tiles they have): 

            //which tile type is it, and how many of them are there

            //Create a new TileStack object and make the TileInventoryUI Gameobject its parent

            //for (x = 0; X < totalTilesOfThisType; x++)
            //{
            //    Instantiate this prefab, and set its parent to the new stack
            //}


        foreach(GameObject uiObject in TileUIObjects)
        {
            //Get the TileUIObject script
            var uiObjectData = uiObject.GetComponent<TileUIObject>();

            uiObjectData.uiCamera = uiCamera;

            //Check which tile it is and generate those tiles based on an int of how many tiles there are of that type
            switch(uiObjectData.tileType)
            {
                //FOREST////////////////////////////////////////////////////////////
                case TileUIObject.TileType.forest:

                    var forestTileStack = Instantiate(TileStackObject, Vector3.zero, Quaternion.identity);
                    forestTileStack.transform.SetParent(this.gameObject.transform, false);

                    for (int x=0; x < forestTiles; x++)
                    {
                        var obj = Instantiate(uiObject, Vector3.zero, Quaternion.identity);
                        obj.transform.SetParent(forestTileStack.transform, false);
                        var objData = obj.GetComponent<TileUIObject>();
                        objData.tileManager = tileManager;
                    }

                    forestTileStack.GetComponent<TileStack>().ColliderActivation();

                    break;

                //MOUNTAIN////////////////////////////////////////////////////////////
                case TileUIObject.TileType.mountain:

                    var mountainTileStack = Instantiate(TileStackObject, Vector3.zero, Quaternion.identity);
                    mountainTileStack.transform.SetParent(this.gameObject.transform, false);

                    for (int x = 0; x < mountainTiles; x++)
                    {
                        var obj = Instantiate(uiObject, Vector3.zero, Quaternion.identity);
                        obj.transform.SetParent(mountainTileStack.transform, false);
                        var objData = obj.GetComponent<TileUIObject>();
                        objData.tileManager = tileManager;

                    }

                    mountainTileStack.GetComponent<TileStack>().ColliderActivation();

                    break;
            }
        }

    }
}
