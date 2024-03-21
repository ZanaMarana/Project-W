using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerObjOrientation : NetworkBehaviour
{
    public Transform cameraTransform;

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) { return; }
        transform.rotation = Quaternion.Euler(0, cameraTransform.rotation.y, 0);
    }
}
