using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : Dog
{
    private Marker marker;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        marker = GetComponent<Marker>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if ( Input.GetButton("Fire1") )
        {
            playerMovement.canMove = false;
            marker.isMarking = true;
        }
        else
        {
            playerMovement.canMove = true;
            marker.isMarking = false;
        }
    }

}
