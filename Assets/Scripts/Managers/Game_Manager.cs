using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : Manager
{
    public GameState currentGameState;

    public override void Initialize()
    {
        currentGameState = GameState.None;
    }

    public bool TryEnterState( GameState newState)
    {
        if (currentGameState == newState)
        {
            return false;
        }
        else
        {
            Debug.Log("Game State Changed to: " + newState);
            //Fire Event Here
            return true;
        }
    }
}
