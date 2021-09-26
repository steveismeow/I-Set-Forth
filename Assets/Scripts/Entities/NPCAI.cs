using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour
{
    [SerializeField]
    private NPC npc;

    private TileManager tileManager;
    private ActionManager actionManager;

    [SerializeField]
    private int currentAP;


    void OnEnable()
    {
        tileManager = npc.tileManager;
        actionManager = npc.actionManager;
        currentAP = npc.curAP;
        print("AI's currentAP total is: " + currentAP + "/");
        print("NPC's curAP total is: " + npc.curAP);

        StartCoroutine(TestWaitPeriod());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator TestWaitPeriod()
    {
        yield return new WaitForSeconds(2f);

        npc.ExitTurnState();
    }
}
