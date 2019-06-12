using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniffer : MonoBehaviour
{
    public int SnifferLevel = 1;
    public float SnifferRange = 1.0f;
    public LayerMask layerMask;

    public List<Interactable> interactablesInsideSnifferRange;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire Button 1 has been pressed");
            //Create a sphere
            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, SnifferRange, layerMask);
            interactablesInsideSnifferRange = new List<Interactable>();

            if (collidersInRange.Length > 0)
            {
                for (int i = 0; i < collidersInRange.Length; i++)
                {
                    if (collidersInRange[i].GetComponent<Interactable>() != null)
                    {
                        Interactable interactable = collidersInRange[i].GetComponent<Interactable>();
                        interactable.isBeingSniffed = true;
                        interactablesInsideSnifferRange.Add(interactable);
                    }
                }
            }
            
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Fire Button 1 has been released");

            if (interactablesInsideSnifferRange.Count > 0)
            {
                for (int i = 0; i < interactablesInsideSnifferRange.Count; i++)
                {
                    interactablesInsideSnifferRange[i].isBeingSniffed = false;
                }
                interactablesInsideSnifferRange.Clear();
            }
        }
    }
}
