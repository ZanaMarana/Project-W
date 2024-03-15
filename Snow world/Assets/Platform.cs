using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public Vector3 firstPos;
    public Vector3 secondPos;
    public Vector3 movementVector;
    bool goingForward;

    public Collider collider;

    Transform parentTransform;

    public float movementSpeed;
    public float movementProgress;

    public void Start()
    {
        goingForward = true;

        transform.position = firstPos;
        movementVector = new Vector3(Mathf.Abs(firstPos.x - secondPos.x) * (firstPos.x > secondPos.x ? 1 : -1), Mathf.Abs(firstPos.y - secondPos.y) * (firstPos.y > secondPos.y ? 1 : -1), Mathf.Abs(firstPos.z - secondPos.z) * (firstPos.z > secondPos.z ? 1 : -1));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goingForward)
        {
            if(movementProgress + movementSpeed >= 1)
            {
                movementProgress = 1;
                updateMovement();
                goingForward = false;
            }
            else 
            {
                movementProgress += movementSpeed;
                updateMovement();
            }
        }
        else
        {
            if (movementProgress - movementSpeed <= 0)
            {
                movementProgress = 0;
                updateMovement();
                goingForward = true;
            }
            else
            {
                updateMovement();
                movementProgress -= movementSpeed;
            }
        }
    }

    private void updateMovement()
    {
        transform.position = new Vector3(firstPos.x + (movementVector.x * movementProgress), firstPos.y + (movementVector.y * movementProgress), firstPos.z + (movementVector.z * movementProgress));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && other.GetComponent<PlayerMovement>().grounded)
        {
            parentTransform = other.transform.parent;
            other.transform.SetParent(this.transform);
            Debug.Log("Did it");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.transform.SetParent(parentTransform);
        }
    }
}
