using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckUpdate : MonoBehaviour
{

    PlayerMovement playerScript;

    private void Start()
    {
        playerScript = GetComponentInParent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerScript.flipFlopDrag();
        Debug.Log("entered");
    }

    private void OnCollisionExit(Collision collision)
    {
        playerScript.flipFlopDrag();
        Debug.Log("exited");
    }
}
