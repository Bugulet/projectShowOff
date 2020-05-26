using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesGetScoreOverTIme : MonoBehaviour
{
	private ScoreCounter scoreCounter;
	[SerializeField]
	private int scoreToCollect;

	public GameObject CollectScoreButton;

	[SerializeField]
	private float editorCounter;
	private float counter;
	void Start()
	{
		scoreCounter = FindObjectOfType<ScoreCounter>();
		
		counter = editorCounter;
	}

	// Update is called once per frame
	void Update()
	{
		counter -= Time.deltaTime;
		print(counter);
		if(counter <= 0)
		{
			
			CollectScoreButton.SetActive(true);
		}
	}
	public void CollectScore()
	{
		
		scoreCounter.IncreaseTheScore(scoreToCollect);
		counter = editorCounter;
	
		CollectScoreButton.SetActive(false);
	}
}
