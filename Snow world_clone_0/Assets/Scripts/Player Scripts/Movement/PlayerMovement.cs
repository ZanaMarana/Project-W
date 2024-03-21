using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 1f;
    public float sprintSpeed = 1.5f;
    public float jumpForce = 100f;
    float sprinting;

    public float addedGrav; 

    [Header("Ground Check")]
    public bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.4f;
    public LayerMask groundMask;

    public Transform orientation;

    Vector3 moveDir;

    public Rigidbody rb;

    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference sprint;
    
    private void Start()
    {
        grounded = true;
        sprinting = 0;
    }

    private void OnEnable()
    {
        if (!IsOwner) { return; }
        jump.action.started += Jump;
       //sprint.action.started += Sprint;
    }

    private void OnDisable()
    {
        if (!IsOwner) { return; }
        jump.action.started -= Jump;
        //sprint.action.started -= Sprint;
    }

    private void Update()
    {
        if (!IsOwner) { return; }
        grounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
        speedControl();
    }

    private void FixedUpdate()
    {
        if (!IsOwner) { return; }
        movePlayer();
        if (!grounded)
        {
            addGravity();
        }
    }

    private void movePlayer()
    {
        sprinting = sprint.action.ReadValue<float>();
        Vector2 moveValue = move.action.ReadValue<Vector2>();
        moveDir = orientation.forward * moveValue.y + orientation.right * moveValue.x;

        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void addGravity()
    {
        float yVelocity = rb.velocity.y - addedGrav;
        rb.velocity = new Vector3 (rb.velocity.x, yVelocity, rb.velocity.z);
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

        
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    /*
    private void Sprint(InputAction.CallbackContext obj)
    {
        if (!sprinting)
        {
            sprinting = true;
            Debug.Log("Sprinting");
        }
        else
        {
            sprinting = false;
            Debug.Log("not spirnting");
        }
    }
    */
}
