using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class PlayerCam : NetworkBehaviour
{
    public InputActionReference look;

    [Range(0f, 1f)]
    public float sensX = 0.5f;
    [Range(0f, 1f)]
    public float sensY = 0.5f;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        if (!IsLocalPlayer) return; 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!IsLocalPlayer) return;
        Vector2 lookVector = look.action.ReadValue<Vector2>();

        xRotation -= lookVector.y * 0.2f * sensX;
        yRotation += lookVector.x * 0.2f * sensY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
