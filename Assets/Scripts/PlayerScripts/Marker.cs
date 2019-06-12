using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public Color GizmoColor;
    public int MarkerLevel = 1;
    public float MarkerRange = 1.0f;
    public LayerMask layerMask;

    public List<Interactable> interactablesInsideMarkerRange;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //Debug.Log("Fire Button 2 has been pressed");
            //Create a sphere
            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, MarkerRange, layerMask);
            interactablesInsideMarkerRange = new List<Interactable>();

            if (collidersInRange.Length > 0)
            {
                for (int i = 0; i < collidersInRange.Length; i++)
                {
                    if (collidersInRange[i].GetComponent<Interactable>() != null)
                    {
                        Interactable interactable = collidersInRange[i].GetComponent<Interactable>();
                        interactable.isBeingMarked = true;
                        interactablesInsideMarkerRange.Add(interactable);
                    }
                }
            }

        }

        if (Input.GetButtonUp("Fire2"))
        {
            //Debug.Log("Fire Button 2 has been released");

            if (interactablesInsideMarkerRange.Count > 0)
            {
                for (int i = 0; i < interactablesInsideMarkerRange.Count; i++)
                {
                    interactablesInsideMarkerRange[i].isBeingMarked = false;
                }
                interactablesInsideMarkerRange.Clear();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = GizmoColor;
        if (Input.GetButtonUp("Fire2"))
        {
            Gizmos.DrawSphere(transform.position, MarkerRange);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position, MarkerRange);
        }

    }
}
