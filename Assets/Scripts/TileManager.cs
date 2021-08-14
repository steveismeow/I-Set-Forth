using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{

    [SerializeField]
    private Tilemap tileMap;

    [SerializeField]
    private List<TileData> tileDataList;



    private Dictionary<TileBase, TileData> dataFromTiles;
    private Dictionary<string, TileData> tileNameCodex;


    #region Unity Callback Functions
    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();
        tileNameCodex = new Dictionary<string, TileData>();

        foreach (var tileData in tileDataList)
        {
            dataFromTiles.Add(tileData.tile, tileData);
            tileNameCodex.Add(tileData.name, tileData);

            foreach (var key in tileNameCodex.Keys)
            {
                print(key);

            }
        }
    }

    private void Start()
    {
        InitialTileAdjacencySetUp();

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = tileMap.WorldToCell(mousePosition);

            TileBase selectedTile = tileMap.GetTile(gridPosition);

            float movementDifficulty = dataFromTiles[selectedTile].moveDifficulty;
            float rangeMultiplier = dataFromTiles[selectedTile].rangeMultiplier;

            print(selectedTile + "at position" + gridPosition);
            print("Movement difficulty =" + movementDifficulty);
            print("Range multiplier =" + rangeMultiplier);

        }
    }

    #endregion


    private List<Vector3> GetTileLocations()
    {
        List<Vector3> tileWorldLocations = new List<Vector3>();

        foreach (var pos in tileMap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPos = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 position = tileMap.CellToWorld(localPos);

            if (tileMap.HasTile(localPos))
            {
                tileWorldLocations.Add(localPos);
            }
        }

        return tileWorldLocations;

    }

    private void InitialTileAdjacencySetUp()
    {
        List<Vector3> tileLocations = GetTileLocations();

        foreach (var loc in tileLocations)
        {
            PlacementTileAdjacency(loc);
        }

    }

    private void PlacementTileAdjacency(Vector3 tileLocation)
    {
        for (int x = (int)(tileLocation.x - 1); x <= (int)(tileLocation.x + 1); x++)
        {
            for (int y = (int)(tileLocation.y - 1); y <= (int)(tileLocation.y + 1); y++)
            {
                Vector3Int locVector = new Vector3Int(x, y, (int)tileLocation.z);

                if (tileMap.GetTile(locVector) == null)
                {
                    //set space tile
                    tileMap.SetTile(locVector, tileNameCodex["Placement Tile"].tile);
                }


            }
        }

    }

    //Place Tile ()

}




//BoundsInt locBounds = new BoundsInt((int)(loc.x - 1), (int)(loc.y - 1), (int)(loc.z), 3, 3, 0 );

//TileBase[] tiles = tileMap.GetTilesBlock(locBounds);

//print(tiles.Length);

////check for null
//for(int x= 0; x < tiles.Length; x++)
//{
//    TileBase curTile = tiles[x];

//    print(curTile.name);

//    print("lmao");

//    //if (curTile == null)
//    //{
//    //    //set tile

//    //}
//}
//}
