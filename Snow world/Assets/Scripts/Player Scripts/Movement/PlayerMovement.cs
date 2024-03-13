using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 1f;

    public Transform orientation;

    Vector3 moveDir;

    public Rigidbody rb;

    public InputActionReference move;

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
}
