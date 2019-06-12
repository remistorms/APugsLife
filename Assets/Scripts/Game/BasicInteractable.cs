using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteractable : Interactable
{
    public void Update()
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

    public override void OnBarked()
    {

    }

    public override void OnEaten()
    {

    }

    public override void OnMarked()
    {

    }

    public override void OnSniffed()
    {
        Destroy(this.gameObject);
    }
}
