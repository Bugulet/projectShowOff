using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    [SerializeField]
    Text scoreText;

    public int Score { get; private set; }
	void Start()
    {
		Score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateScore()
    {
        scoreText.text ="Score: "+ Score;
    }

	public void IncreaseTheScore(int amountToAdd)
	{
		Score += amountToAdd;
        updateScore();
	}
	public void DecreaseTheScore(int amountToAdd)
	{
		Score -= amountToAdd;
        updateScore();
    }
}
