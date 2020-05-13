using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static void GoToStart()
    {
        SceneManager.LoadScene(0);
    }

    public static void GoToGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToGameWrapper()
    {
        GoToGame();
    }

}
