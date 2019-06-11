using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGameState : MonoBehaviour
{
    public GameState gameStateToSwitchTo;

    public void ChangeState()
    {
            GLOBAL.instance.m_Events.Fire_EVT_GameStateChanged(gameStateToSwitchTo);
    }

}
