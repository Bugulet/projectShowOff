﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour
{

    [SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text positiveFeedbackText;
	[SerializeField]
	private Text negativeFeedbackText;

	private Text InstanceHolder;
	private Canvas canvas;


	
    public int Score { get; private set; }
	
	void Start()
    {
		Score = 0;
		canvas = FindObjectOfType<Canvas>();
    }
    // Update is called once per frame
    void Update()
    {
		
    }

    private void updateScoreText()
    {
        scoreText.text ="Score: "+ Score;
    }

	public void IncreaseTheScore(int amountToAdd)
	{
		InstanceHolder = Instantiate(positiveFeedbackText, Input.mousePosition, Quaternion.identity, canvas.transform);
        InstanceHolder.GetComponent<Text>().text = "+" + amountToAdd + " score";
		Score += amountToAdd;
        updateScoreText();
		StartCoroutine(ChangeTextColorGreen());

		PlayerPrefs.SetInt("score", Score);
	}
	public void DecreaseTheScore(int amountToAdd)
	{
		InstanceHolder = Instantiate(negativeFeedbackText, Input.mousePosition, Quaternion.identity, canvas.transform);
        InstanceHolder.GetComponent<Text>().text = "-" + amountToAdd + " score";
        Score -= amountToAdd;
        updateScoreText();
		StartCoroutine(ChangeTextColorRed());
		PlayerPrefs.SetInt("score", Score);
		
    }
	IEnumerator ChangeTextColorGreen()
	{
		scoreText.color = Color.green;
		yield return new WaitForSeconds(3);
		scoreText.color = Color.white;
	}
	IEnumerator ChangeTextColorRed()
	{
		scoreText.color = Color.red;
		yield return new WaitForSeconds(3);
		scoreText.color = Color.white;
	}

}
