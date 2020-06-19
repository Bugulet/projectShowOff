using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContainer : MonoBehaviour
{
   
    void Start()
    {
        
    }

  
    void Update()
    {
		StartCoroutine(CloseBuble());
    }
	private IEnumerator CloseBuble()
	{
		yield return new WaitForSeconds(3);
		this.gameObject.SetActive(false);
	}
}
