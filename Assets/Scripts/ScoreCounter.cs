using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreCounter : MonoBehaviour
{

    [SerializeField]
	private TextMeshProUGUI scoreText;
	[SerializeField]
	private TextMeshProUGUI positiveFeedbackText;
	[SerializeField]
	private TextMeshProUGUI negativeFeedbackText;
	[SerializeField]
	private GameObject StarToInstantiate;
	[SerializeField]
	private TextMeshProUGUI TimesUpText;
	private TextMeshProUGUI InstanceHolder;
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
		if (Input.GetKey(KeyCode.V))
		{
			IncreaseTheScore(1);
		}
		TimesUpText.text = " " + Score; 
    }

    private void updateScoreText()
    {
        scoreText.text =" " + Score;
    }

	public void IncreaseTheScore(int amountToAdd)
	{
		InstanceHolder = Instantiate(positiveFeedbackText, Input.mousePosition, Quaternion.identity, canvas.transform);
        InstanceHolder.GetComponent<TextMeshProUGUI>().text = "+" + amountToAdd;
		InstanceHolder.GetComponent<TextMeshProUGUI>().faceColor = new Color32(255,255,0,255);
		Score += amountToAdd;
        updateScoreText();
		StartCoroutine(ChangeTextColorGreen());
		
		GameObject Star = Instantiate(StarToInstantiate, Input.mousePosition, Quaternion.identity,canvas.transform);
		Star.SetActive(true);
		PlayerPrefs.SetInt("score", Score);
	}
	public void DecreaseTheScore(int amountToAdd)
	{
		InstanceHolder = Instantiate(negativeFeedbackText, Input.mousePosition, Quaternion.identity, canvas.transform);
        InstanceHolder.GetComponent<TextMeshProUGUI>().text = "-" + amountToAdd;
		InstanceHolder.GetComponent<TextMeshProUGUI>().faceColor = new Color32(255, 0, 0, 255);
		Score -= amountToAdd;
        updateScoreText();
		StartCoroutine(ChangeTextColorRed());
		PlayerPrefs.SetInt("score", Score);
		
    }
	IEnumerator ChangeTextColorGreen()
	{
		scoreText.color = new Color32(255, 255, 0, 255);
		yield return new WaitForSeconds(3);
		scoreText.color = Color.white;
	}
	IEnumerator ChangeTextColorRed()
	{
		scoreText.color = new Color32(255, 0, 0, 255);
		yield return new WaitForSeconds(3);
		scoreText.color = Color.white;
	}

}
