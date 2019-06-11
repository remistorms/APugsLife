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

    public event Action<Markable> EVT_MarkedNewObject = delegate { };
    public void Fire_EVT_MarkedNewObject ( Markable _markedObject )
    {
        EVT_MarkedNewObject(_markedObject);
    }

    public override void Initialize()
    {
  
    }
}
