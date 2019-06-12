using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barker : MonoBehaviour
{
    public Color GizmoColor;
    public int BarkerLevel = 1;
    public float BarkerRange = 1.0f;
    public LayerMask layerMask;

    public List<Interactable> interactablesInsideBarkerRange;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Jump Button has been pressed");
            //Create a sphere
            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, BarkerRange, layerMask);
            interactablesInsideBarkerRange = new List<Interactable>();

            if (collidersInRange.Length > 0)
            {
                for (int i = 0; i < collidersInRange.Length; i++)
                {
                    if (collidersInRange[i].GetComponent<Interactable>() != null)
                    {
                        Interactable interactable = collidersInRange[i].GetComponent<Interactable>();
                        interactable.isBeingBarked = true;
                        interactablesInsideBarkerRange.Add(interactable);
                    }
                }
            }

        }

        if (Input.GetButtonUp("Jump"))
        {
            //Debug.Log("Jump Button has been released");

            if (interactablesInsideBarkerRange.Count > 0)
            {
                for (int i = 0; i < interactablesInsideBarkerRange.Count; i++)
                {
                    interactablesInsideBarkerRange[i].isBeingBarked = false;
                }
                interactablesInsideBarkerRange.Clear();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = GizmoColor;
        if (Input.GetButtonUp("Jump"))
        {
            Gizmos.DrawSphere(transform.position, BarkerRange);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position, BarkerRange);
        }

    }
}
