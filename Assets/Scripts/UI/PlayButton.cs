using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        GLOBAL.instance.m_Level.LoadLevel(2);
    }
}
