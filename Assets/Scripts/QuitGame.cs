using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuitGame : MonoBehaviour
{
	private void Start()
	{
#if UNITY_WEBGL
		this.gameObject.SetActive(false);
#endif
	}
	public void Quit()
    {
		Application.Quit();
    }
	
}
