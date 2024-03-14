using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 1f;
    public float jumpForce = 100f;
    float sprinting;

    public float groundDrag;

    [Header("Ground Check")]
    bool grounded;

    public Transform orientation;

    Vector3 moveDir;

    public Rigidbody rb;

    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference sprint;
    
    private void Start()
    {
        grounded = true;
        rb.drag = groundDrag;
        sprinting = 0;
    }

    private void OnEnable()
    {
        jump.action.started += Jump;
       //sprint.action.started += Sprint;
    }

    private void OnDisable()
    {
        jump.action.started -= Jump;
        //sprint.action.started -= Sprint;
    }

    private void Update()
    {
        speedControl();
    }

    public void flipFlopDrag()
    {
        if (!grounded)
        {
            rb.drag = groundDrag;
            grounded = true;
        }
        else
        {
            rb.drag = 0;
            grounded = false;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        sprinting = sprint.action.ReadValue<float>();
        Debug.Log(sprinting);
        Vector2 moveValue = move.action.ReadValue<Vector2>();
        moveDir = orientation.forward * moveValue.y + orientation.right * moveValue.x;

        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
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
