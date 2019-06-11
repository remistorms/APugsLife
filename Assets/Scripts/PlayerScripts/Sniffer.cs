using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniffer : MonoBehaviour
{
    public bool isSniffing;

    private void Update()
    {
        if ( Input.GetKey(KeyCode.Space) )
        {
            isSniffing = true;
        }
        else
        {
            isSniffing = false;
        }
    }

}
