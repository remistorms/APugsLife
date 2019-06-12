using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
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
    public float sniffPercentage;
    protected float sniffCurrentTime;
    public float sniffTimeNeeded;
    [Range(0, 1)]
    public float barkPercentage;
    protected float barkCurrentTime;
    public float barkTimeNeeded;
    [Range(0, 1)]
    public float eatPercentage;
    protected float eatCurrentTime;
    public float eatTimeNeeded;
    [Range(0, 1)]
    public float markPercentage;
    protected float markCurrentTime;
    public float markTimeNeeded;

    //Public Methods
    public abstract void OnSniffed();
    public abstract void OnBarked();
    public abstract void OnEaten();
    public abstract void OnMarked();

}
