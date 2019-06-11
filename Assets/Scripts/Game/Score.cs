using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Score : MonoBehaviour
{
    public int highScore;
    public int currentScore;
    public TextMeshProUGUI scoreLabel;


    private void Awake()
    {
        currentScore = 0;
        scoreLabel = GetComponent<TextMeshProUGUI>();
        scoreLabel.text = "Score: " + currentScore;
    }

    private void Start()
    {
        GLOBAL.instance.m_Events.EVT_MarkedNewObject += OnNewObjectMarked;
    }

    private void OnNewObjectMarked(Markable _markable)
    {
        StartCoroutine( AddToScore ( _markable.pointsForMarking ) );
    }

    IEnumerator AddToScore(int _amountToAdd)
    {
        for (int i = 0; i < _amountToAdd; i++)
        {
            currentScore++;
            scoreLabel.text = "Score: " + currentScore;
            yield return new WaitForSeconds( 0.01f);
        }
    }
}
