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

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDataList)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
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
}
