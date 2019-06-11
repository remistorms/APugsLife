using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public bool isMarking = false;
    public float waterLevel;
    public float waterDepleteSpeed;
    public Transform markerPosition;


    private void Update()
    {
        if ( isMarking)
        {
            Mark();
        }
    }

    public void Mark()
    {
        if (waterLevel <= 0)
        {
            waterLevel = 0;
        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(markerPosition.position, 1f);

            foreach (var col in colliders)
            {
                if (col.GetComponent<Markable>() != null)
                {
                    col.GetComponent<Markable>().Mark( Time.deltaTime * waterDepleteSpeed );
                }
            }

            waterLevel -= Time.deltaTime * waterDepleteSpeed;
        }
    }

    public void FillWaterLevel(float _waterLevel)
    {
        waterLevel += _waterLevel;
    }
}
