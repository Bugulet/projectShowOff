using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Score { get; private set; }
	void Start()
    {
		Score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
	public void IncreaseTheScore(int amountToAdd)
	{
		Score += amountToAdd;
	}
}
