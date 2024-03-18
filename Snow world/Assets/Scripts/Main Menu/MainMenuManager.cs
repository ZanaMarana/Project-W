using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static int chosenMultiplayerMode = -1;
    public void HostButton()
    {
        chosenMultiplayerMode = 1;
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void JoinButton()
    {
        chosenMultiplayerMode = 2;
        SceneManager.LoadSceneAsync("SampleScene");
    }
}
