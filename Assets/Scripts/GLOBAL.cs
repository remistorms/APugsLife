using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLOBAL : MonoBehaviour
{
    public static GLOBAL instance;

    public Game_Manager m_Game;
    public Events_Manager m_Events;
    public Level_Manager m_Level;
    public IO_Manager m_IO;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);

        StartCoroutine(InitializeManagersRoutine());
 
    }

    //Initializes them in order
    IEnumerator InitializeManagersRoutine()
    {
        //Wait
        yield return null;

        //Initializes Managers
        m_Game.Initialize();
        m_Events.Initialize();
        m_Level.Initialize();
        m_IO.Initialize();

        //Another wait
        yield return null;

        // Load scene 1
        m_Level.LoadLevel(1);
    }
}
