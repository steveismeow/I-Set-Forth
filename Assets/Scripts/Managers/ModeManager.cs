using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public enum GameMode
    {
        travelMode,
        engagementMode
    }

    public GameMode currentGameMode;


    private void Start()
    {
        currentGameMode = GameMode.travelMode;
    }

    private void FixedUpdate()
    {
        switch (currentGameMode)
        {
            case GameMode.travelMode:
                //activate travel mode mechanics: change the turn manager state? 

                break;

            case GameMode.engagementMode:
                //activate engagement mode mechanics: change turn manager state? activate combat manager?

                break;
        }
    }
}
