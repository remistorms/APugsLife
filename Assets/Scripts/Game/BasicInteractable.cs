using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteractable : Interactable
{
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
                OnSniffed();
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
                OnBarked();
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
                OnMarked();
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
                OnEaten();
            }
        }
        else
        {
            eatCurrentTime = 0;
            eatPercentage = 0;
        }
    }


    //ON INTERACTED WITH
    public override void OnBarked()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }

    public override void OnEaten()
    {
        Destroy(this.gameObject);
    }

    public override void OnMarked()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.green;
    }

    public override void OnSniffed()
    {
        this.transform.localScale = new Vector3(2,2,2);
    }
}
