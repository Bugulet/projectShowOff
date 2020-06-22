using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
	[SerializeField]
	public float TimerCount;
	public Text TimerText;

	
	[SerializeField]
	private GameObject endPanel;
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		if (Globals.isGameOver == false)
		{
			TimerCount -= Time.deltaTime;
		}
		TimerText.text = ($" {TimerCount.ToString("F0")}");
		if(TimerCount <= 0)
		{
			
			Globals.isGameOver = true;
			
			endPanel.SetActive(true);
			
		}
		print(Globals.isGameOver);
		
    }
}
