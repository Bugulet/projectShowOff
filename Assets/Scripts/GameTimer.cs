using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
	[SerializeField]
	public float TimerCount;
	public Text TimerText;
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		TimerCount -= Time.deltaTime;
		TimerText.text = ($"The time left is: {TimerCount.ToString("F0")}");
    }
}
