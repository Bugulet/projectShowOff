using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public static void GoToStart() { SceneManager.LoadScene(0); }

    public static void GoToTutorial() { SceneManager.LoadScene(1); }

    public static void GoToGame() { SceneManager.LoadScene(2); }

    public static void GoToEnd() { SceneManager.LoadScene(3); }

    public void GoToGameWrapper() { GoToGame(); }

    public void GoToStartWrapper() { GoToStart(); }

    public void GoToTutorialWrapper() { GoToTutorial(); }

    public void GoToScoreboard() { SceneManager.LoadScene(4); }

}
