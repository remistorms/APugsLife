using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [Header("Basic Info")]
    public string interactableName;

    [Header("Interactability Status")]
    public bool isBeingSniffed;
    public bool isBeingBarked;
    public bool isBeingEaten;
    public bool isBeingMarked;

    [Header("Interactability Status")]
    public bool hasBeenSniffed;
    public bool hasBeenBarked;
    public bool hasBeenEaten;
    public bool hasBeenMarked;

    [Header("Interactability Times")]
    [Range(0, 1)]
    public float sniffPercentage = 0;
    protected float sniffCurrentTime = 0;
    public float sniffTimeNeeded = 1;
    [Range(0, 1)]
    public float barkPercentage = 0;
    protected float barkCurrentTime = 0;
    public float barkTimeNeeded = 1;
    [Range(0, 1)]
    public float eatPercentage = 0;
    protected float eatCurrentTime = 0;
    public float eatTimeNeeded = 1;
    [Range(0, 1)]
    public float markPercentage = 0;
    protected float markCurrentTime = 0;
    public float markTimeNeeded = 1;

    public void Update()
    {
        UpdateSniffState();
        UpdateBarkState();
        UpdateEatState();
        UpdateMarkState();
    }

    //THIS UPDATEDS SLIDER VALUES
    private void UpdateSniffState()
    {
        if (isBeingSniffed && hasBeenSniffed == false)
        {
            sniffCurrentTime += Time.deltaTime;
            sniffPercentage = sniffCurrentTime / sniffTimeNeeded;

            if (sniffCurrentTime >= sniffTimeNeeded)
            {
                sniffCurrentTime = sniffTimeNeeded;
                hasBeenSniffed = true;
                OnSniffedComplete();
            }
        }
        else
        {
            sniffCurrentTime = 0;
            sniffPercentage = 0;
        }
    }

    private void UpdateBarkState()
    {
        if (isBeingBarked && hasBeenBarked == false)
        {
            barkCurrentTime += Time.deltaTime;
            barkPercentage = barkCurrentTime / barkTimeNeeded;

            if (barkCurrentTime >= barkTimeNeeded)
            {
                barkCurrentTime = barkTimeNeeded;
                hasBeenBarked = true;
                OnBarkedComplete();
            }
        }
        else
        {
            barkCurrentTime = 0;
            barkPercentage = 0;
        }
    }

    private void UpdateMarkState()
    {
        if (isBeingMarked && hasBeenMarked == false)
        {
            markCurrentTime += Time.deltaTime;
            markPercentage = markCurrentTime / markTimeNeeded;

            if (markCurrentTime >= markTimeNeeded)
            {
                markCurrentTime = markTimeNeeded;
                hasBeenMarked = true;
                OnMarkedComplete();
            }
        }
        else
        {
            markCurrentTime = 0;
            markPercentage = 0;
        }
    }

    private void UpdateEatState()
    {
        if (isBeingEaten && hasBeenEaten == false)
        {
            eatCurrentTime += Time.deltaTime;
            eatPercentage = eatCurrentTime / eatTimeNeeded;

            if (eatCurrentTime >= eatTimeNeeded)
            {
                eatCurrentTime = eatTimeNeeded;
                hasBeenEaten = true;
                OnEatenComplete();
            }
        }
        else
        {
            eatCurrentTime = 0;
            eatPercentage = 0;
        }
    }


    //ON INTERACTED WITH
    public void OnBarkedComplete()
    {
       // GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }

    public void OnEatenComplete()
    {
       // Destroy(this.gameObject);
    }

    public void OnMarkedComplete()
    {
        //GetComponentInChildren<MeshRenderer>().material.color = Color.green;
    }

    public void OnSniffedComplete()
    {
        //this.transform.localScale = new Vector3(2,2,2);
    }
}
