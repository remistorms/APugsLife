using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Events_Manager : Manager
{ 
    //Game State Changed
    public event Action<GameState> EVT_GameStateChanged = delegate { };
    public void Fire_EVT_GameStateChanged(GameState state)

    {
        EVT_GameStateChanged(state);
    }
    public override void Initialize()
    {
  
    }
}
