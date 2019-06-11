using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Instance Specific Fields")]
    public bool canMove = true;
    [SerializeField] private float moveSpeed;

    //Private fields
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        DetectInput();
        Move();
        Rotate();
    }

    private void DetectInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

    }

    public void Move()
    {
        if (canMove)
        {
            controller.SimpleMove(moveDirection * moveSpeed);
        }
       
    }

    private void Rotate()
    {
        if (moveDirection.magnitude > 0 &&  canMove == true)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            Quaternion lerpedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * 10);
            transform.rotation = lerpedRotation;
        }
        else if(moveDirection.magnitude > 0 && canMove == false)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            Quaternion lerpedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * 2);
            transform.rotation = lerpedRotation;
        }
    }
}
