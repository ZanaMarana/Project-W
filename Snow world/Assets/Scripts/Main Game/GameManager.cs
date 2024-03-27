using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(MainMenuManager.chosenMultiplayerMode == 1)
        {
            NetworkManager.Singleton.StartHost();
            Debug.Log("Game Manager started host");
        }
        else
        {
            NetworkManager.Singleton.StartClient();
            Debug.Log("Game Manager started cloient");
        }
        
    }
}
