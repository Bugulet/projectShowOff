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
	public Jun_Tween jun_tween;
	[SerializeField]
	private float editorCounter;
	[SerializeField]
	private float timeUntilButtonDissapears;
	private float counter;

	void Start()
	{
		scoreCounter = FindObjectOfType<ScoreCounter>();
		counter = editorCounter;
	}

	// Update is called once per frame
	void Update()
	{
		if (Globals.isGameOver == false)
		{
			counter -= Time.deltaTime;

			if (counter <= 0)
			{
				CollectScoreButton.SetActive(true);
			}

			if (CollectScoreButton.activeSelf == true)
			{
				StartCoroutine(DisableButtonIfNotPressedInTime());
			}
		}
	}

	public void CollectScore()
	{
		scoreCounter.IncreaseTheScore(scoreToCollect);
		counter = editorCounter;
		CollectScoreButton.SetActive(false);
	}

	public IEnumerator DisableButtonIfNotPressedInTime()
	{
		yield return new WaitForSeconds(timeUntilButtonDissapears);
		
        CollectScoreButton.GetComponent<Animator>().Play("Score Alpha");
        yield return new WaitForSeconds(1);

        counter = editorCounter;
        CollectScoreButton.GetComponent<Image>().color = Color.white;
        CollectScoreButton.SetActive(false);
	}
	
}
