using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class MainMenuManager : MonoBehaviour
{
    public static int chosenMultiplayerMode = -1; //Host will equal 1, Join will equal 2
    public void HostButton()
    {
        chosenMultiplayerMode = 1;
        SceneManager.LoadSceneAsync("Game");
    }

    public void JoinButton()
    {
        chosenMultiplayerMode = 2;
        SceneManager.LoadSceneAsync("Game");
    }
}
