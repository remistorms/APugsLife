using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentStateTester : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;

    private void Start()
    {
        GLOBAL.instance.m_Events.EVT_GameStateChanged += OnStateChanged;
    }

    private void OnStateChanged(GameState state)
    {
        Debug.Log("State Changed");
        label.text = "Current State:" + "\n" + state.ToString();
    }
}
