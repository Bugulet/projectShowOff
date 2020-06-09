using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
	public GameObject BadTiles;
	public GameObject CleanTiles;
	public GameObject CleanHouses;
	public GameObject TrashedHouses;
	public GameObject OtherTrash;
	public GameObject RecycleStatue;


	private ScoreCounter scoreCounter;
	[SerializeField]
	private int scoreTresholdForNature;
	[SerializeField]
	private int scoreThresholdForStatue;


	void Start()
    {
		scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {

		if(scoreCounter.Score >= scoreTresholdForNature)
		{
			TrashedHouses.SetActive(false);
			OtherTrash.SetActive(false);
			BadTiles.SetActive(false);
			CleanTiles.SetActive(true);
			CleanHouses.SetActive(true);
			
		}
		if(scoreCounter.Score >= scoreThresholdForStatue)
		{
			RecycleStatue.SetActive(true);
		}
	}
}
