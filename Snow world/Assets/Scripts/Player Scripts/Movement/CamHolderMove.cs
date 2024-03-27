using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CamHolderMove : MonoBehaviour
{
    public Transform cameraPos;
    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos.position;
    }
}
