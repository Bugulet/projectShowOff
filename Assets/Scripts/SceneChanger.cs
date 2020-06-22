using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public static void GoToStart() { Globals.ResetGlobals(); SceneManager.LoadScene(0); }

    public static void GoToTutorial() { Globals.ResetGlobals(); SceneManager.LoadScene(1); }

    public static void GoToGame() { Globals.ResetGlobals(); SceneManager.LoadScene(2); }

    public static void GoToEnd() { Globals.ResetGlobals(); SceneManager.LoadScene(3); }

    public void GoToGameWrapper() { GoToGame(); }

    public void GoToStartWrapper() {  GoToStart(); }

    public void GoToTutorialWrapper() { GoToTutorial();  }
	public void GoToEndWrapper() {   GoToEnd();  }

    public void GoToScoreboard() { SceneManager.LoadScene(4); }

}
