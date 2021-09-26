using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;


public class PlayerTurnInputManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private TileManager tileManager;
    private ActionManager actionManager;

    [SerializeField]
    private int currentAP;


    void OnEnable()
    {
        tileManager = player.tileManager;
        actionManager = player.actionManager;
        currentAP = player.curAP;
        print("InputManager's currentAP total is: "+ currentAP + "/");
        print("Player's curAP total is: " + player.curAP);

    }

    // Update is called once per frame
    void Update()
    {
        //EndTurn
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Player passed their actions, ending turn!");
            player.ExitTurnState();
        }


        //MoveInstantly() action
        if (Input.GetMouseButtonDown(0))
        {
            //Supposed to be stopping clicking behind UI objects...but isn't
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }


            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = tileManager.tileMap.WorldToCell(mousePosition);

            TileBase selectedTile = tileManager.tileMap.GetTile(gridPosition);


            if (selectedTile != null && selectedTile != tileManager.tileNameCodex["Placement Tile"].tile)
            {
                actionManager.MoveInstantly(tileManager.GetTruePosition(gridPosition));
                UseAP(1);
            }
        }
    }

    public void UseAP(int apCost)
    {
        currentAP -= apCost;
        CheckAP();
    }

    private void CheckAP()
    {
        if (currentAP <= 0)
        {
            print("AP = 0, ending turn!");
            player.ExitTurnState();
        }

    }

}
