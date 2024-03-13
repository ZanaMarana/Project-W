using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjOrientation : MonoBehaviour
{
    public Transform cameraTransform;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, cameraTransform.rotation.y, 0);
    }
}
