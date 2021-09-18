using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Script on Tile UIObjects that manages behavior
/// </summary>
public class TileUIObject : MonoBehaviour
{
    public Camera uiCamera;

    public TileManager tileManager;

    private GameObject tileStackObject;

    private TileStack tileStackScript;


    [SerializeField]
    private TileData tileData;

    [SerializeField]
    private SpriteRenderer shadowRenderer;

    [SerializeField]
    private SpriteRenderer renderer;//error on use, i think this is because of a deprecated function though?

    [SerializeField]
    private BoxCollider2D collider;//error on use, i think this is because of a deprecated function though?


    private bool isBeingHeld = false;

    public enum TileType
    {
        forest,
        desert,
        mountain
    }

    public TileType tileType;

    private void Start()
    {
        tileStackObject = transform.parent.gameObject;
        tileStackScript = tileStackObject.GetComponent<TileStack>();
    }

    /// <summary>
    /// While MouseButtonDown, drag object
    /// </summary>
    private void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = uiCamera.ScreenToWorldPoint(mousePos);

            transform.position = new Vector3(mousePos.x, mousePos.y - 0.275f);
        }

    }

    /// <summary>
    /// On MouseButtonDown trigger bool, render order +1 to appear above other tiles
    /// </summary>
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {

            isBeingHeld = true;
            renderer.sortingOrder = 1;
            shadowRenderer.enabled = false;

            transform.SetParent(tileStackObject.transform.parent.parent, false);


        }
    }

    /// <summary>
    /// On MouseButtonUp, either place a tile or return to Tile Inventory Stack
    /// </summary>
    private void OnMouseUp()
    {
        isBeingHeld = false;
        renderer.sortingOrder = 0;
        shadowRenderer.enabled = true;


        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3Int gridPosition = tileManager.tileMap.WorldToCell(mousePos);

        TileBase selectedTile = tileManager.tileMap.GetTile(gridPosition);

        if (selectedTile != null && selectedTile == tileManager.tileNameCodex["Placement Tile"].tile)
        {
            print("you have selected a placement tile");
            tileManager.PlaceTile(gridPosition, tileData.name);
            transform.SetParent(null, false);
            tileStackScript.ColliderActivation();

            Destroy(this.gameObject);

        }
        else
        {
            //transform.position = Vector3.zero;
            transform.SetParent(tileStackObject.transform, false);
            tileStackScript.ColliderActivation();

        }

    }
}
