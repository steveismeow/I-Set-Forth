using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

    private void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0.0f);
        }

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {

            isBeingHeld = true;

        }
    }

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
            transform.position = Vector3.zero;
        }

    }
}
