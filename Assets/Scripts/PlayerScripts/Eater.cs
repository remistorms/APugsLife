using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour
{
    public Color GizmoColor;
    public int EaterLevel = 1;
    public float EaterRange = 1.0f;
    public LayerMask layerMask;

    public List<Interactable> interactablesInsideEaterRange;

    private void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            //Debug.Log("Fire Button 3 has been pressed");
            //Create a sphere
            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, EaterRange, layerMask);
            interactablesInsideEaterRange = new List<Interactable>();

            if (collidersInRange.Length > 0)
            {
                for (int i = 0; i < collidersInRange.Length; i++)
                {
                    if (collidersInRange[i].GetComponent<Interactable>() != null)
                    {
                        Interactable interactable = collidersInRange[i].GetComponent<Interactable>();
                        interactable.isBeingEaten = true;
                        interactablesInsideEaterRange.Add(interactable);
                    }
                }
            }

        }

        if (Input.GetButtonUp("Fire3"))
        {
            //Debug.Log("Fire Button 3 has been released");

            if (interactablesInsideEaterRange.Count > 0)
            {
                for (int i = 0; i < interactablesInsideEaterRange.Count; i++)
                {
                    interactablesInsideEaterRange[i].isBeingEaten = false;
                }
                interactablesInsideEaterRange.Clear();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = GizmoColor;
        if (Input.GetButtonUp("Fire3"))
        {
            Gizmos.DrawSphere(transform.position, EaterRange);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position, EaterRange);
        }

    }
}
