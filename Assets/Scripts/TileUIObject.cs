using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Script on Tile UIObjects that manages behavior
/// </summary>
public class TileUIObject : MonoBehaviour
{
    [SerializeField]
    private Transform tileStack;

    [SerializeField]
    private TileManager tileManager;

    [SerializeField]
    private TileData tileData;

    private bool isBeingHeld = false;

    private void Awake()
    {
        tileStack = transform.parent;
    }

    /// <summary>
    /// While MouseButtonDown, drag object
    /// </summary>
    private void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0.0f);
        }

    }

    /// <summary>
    /// On MouseButtonDown trigger bool
    /// </summary>
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {

            isBeingHeld = true;

        }
    }

    /// <summary>
    /// On MouseButtonUp, either place a tile or return to Tile Inventory Stack
    /// </summary>
    private void OnMouseUp()
    {
        isBeingHeld = false;

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3Int gridPosition = tileManager.tileMap.WorldToCell(mousePos);

        TileBase selectedTile = tileManager.tileMap.GetTile(gridPosition);

        if (selectedTile != null && selectedTile == tileManager.tileNameCodex["Placement Tile"].tile)
        {
            print("you have selected a placement tile");
            tileManager.PlaceTile(gridPosition, tileData.name);

            Destroy(this.gameObject);

        }
        else
        {
            //TODO: fix this
            transform.position = Vector3.zero;
        }

    }
}
