using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CamHolderMove : NetworkBehaviour
{
    public Transform cameraPos;
    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) { return; }
        transform.position = cameraPos.position;
    }
}
