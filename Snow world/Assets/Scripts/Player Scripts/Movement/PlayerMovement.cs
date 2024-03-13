using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 1f;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    Vector3 moveDir;

    public Rigidbody rb;

    public InputActionReference move;

    public Collider groundCheck;

    private void Update()
    {
        grounded = groundCheck.

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        speedControl();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        movePlayer();
    }

    private void movePlayer()
    {
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
}
