using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    //[SerializeField]
    public Tilemap tileMap;

    [SerializeField]
    private List<TileData> tileDataList;

    [SerializeField]
    private int adjacencyRange = 1;


    private Dictionary<TileBase, TileData> dataFromTiles;
    public Dictionary<string, TileData> tileNameCodex;


    #region Unity Callback Functions
    private void Awake()
    {
        //Set Up Dictionaries
        dataFromTiles = new Dictionary<TileBase, TileData>();
        tileNameCodex = new Dictionary<string, TileData>();

        foreach (var tileData in tileDataList)
        {
            dataFromTiles.Add(tileData.tile, tileData);
            tileNameCodex.Add(tileData.name, tileData);

            //Check what keys are available at runtime
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
        //Test to determine what tile is selected and what data is associated with that tile
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = tileMap.WorldToCell(mousePosition);

            TileBase selectedTile = tileMap.GetTile(gridPosition);

            print(selectedTile + "at position" + gridPosition);

            if (selectedTile != null && selectedTile == tileNameCodex["Placement Tile"].tile)
            {
                print("you have selected a placement tile");
                PlaceTile(gridPosition, "Forest Tile");

            }


            //Test variables to ensure we can retrieve the tile's data
            //float movementDifficulty = dataFromTiles[selectedTile].moveDifficulty;
            //float rangeMultiplier = dataFromTiles[selectedTile].rangeMultiplier;


            //print("Movement difficulty =" + movementDifficulty);
            //print("Range multiplier =" + rangeMultiplier);

        }
    }

    #endregion


    #region Get Functions

    //Get all tile Vector3 positions
    private List<Vector3> GetTileLocations()
    {
        List<Vector3> tileWorldLocations = new List<Vector3>();

        foreach (var pos in tileMap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPos = new Vector3Int(pos.x, pos.y, pos.z);
            //Vector3 position = GetVector3FromGridPosition(localPos);

            if (tileMap.HasTile(localPos))
            {
                tileWorldLocations.Add(localPos);
            }
        }

        return tileWorldLocations;

    }

    //Get Vector3 from Vector3Int
    public Vector3 GetVector3FromGridPosition(Vector3Int gridPosition)
    {
        Vector3 position = tileMap.CellToWorld(gridPosition);

        return position;
    }

    //Get Vector3Int from Vector3
    public Vector3Int GetVector3IntFromPosition(Vector3 position)
    {
        Vector3Int gridPosition = new Vector3Int((int)position.x, (int)position.y, (int)position.z);

        return gridPosition;
    }

    public Vector3 GetTruePosition(Vector3Int gridPosition)
    {
        return tileMap.GetCellCenterWorld(gridPosition);
    }

    #endregion


    #region Adjacency
    private void InitialTileAdjacencySetUp()
    {
        List<Vector3> tileLocations = GetTileLocations();

        foreach (var loc in tileLocations)
        {
            PlacementTileAdjacency(loc);
        }

    }

    //Analyze the board and place Placement Tiles adjacent to existing tiles on the tilemap using their Vector3 position
    private void PlacementTileAdjacency(Vector3 tileLocation)
    {
        //Searches a cross-shaped section in all cardinal directions from tileLocation for nuill space and places Placement Tile at each null//////////////////
        //Search x directions
        for (int x = (int)(tileLocation.x - adjacencyRange); x <= (int)(tileLocation.x + adjacencyRange); x++)
        {
            Vector3Int locVector = new Vector3Int(x, (int)tileLocation.y, (int)tileLocation.z);

            if (tileMap.GetTile(locVector) == null)
            {
                //set space tile
                tileMap.SetTile(locVector, tileNameCodex["Placement Tile"].tile);
            }
        }
        //Search y directions
        for (int y = (int)(tileLocation.y - adjacencyRange); y <= (int)(tileLocation.y + adjacencyRange); y++)
        {
            Vector3Int locVector = new Vector3Int((int)tileLocation.x, y, (int)tileLocation.z);

            if (tileMap.GetTile(locVector) == null)
            {
                //set space tile
                tileMap.SetTile(locVector, tileNameCodex["Placement Tile"].tile);
            }
        }
    }

    #endregion

    //Set Placement Tiles at startup


        ////Searches a 3x3 grid centered on the tileLocation for null space and places Placement Tile at each null////////////////////////////////////////////////
        //for (int x = (int)(tileLocation.x - adjacencyRange); x <= (int)(tileLocation.x + adjacencyRange); x++)
        //{
        //    for (int y = (int)(tileLocation.y - adjacencyRange); y <= (int)(tileLocation.y + adjacencyRange); y++)
        //    {
        //        Vector3Int locVector = new Vector3Int(x, y, (int)tileLocation.z);

        //        if (tileMap.GetTile(locVector) == null)
        //        {
        //            //set space tile
        //            tileMap.SetTile(locVector, tileNameCodex["Placement Tile"].tile);
        //        }
        //    }
        //}


    //Place Tile
    public void PlaceTile(Vector3Int gridPosition, string tileName)
    {
        tileMap.SetTile(gridPosition, tileNameCodex[tileName].tile);

        Vector3 position = GetVector3FromGridPosition(gridPosition);

        print(position);

        PlacementTileAdjacency(position);

    }
}