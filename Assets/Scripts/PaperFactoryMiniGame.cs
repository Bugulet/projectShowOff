﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperFactoryMiniGame : MonoBehaviour , MinigameInterface
{
	private int tapCounter = 0;

	public Image image;
	public Sprite[] MinigameSprites;

    [Tooltip("The times you click to recycle.")]
    [Range(1, 10)]
    [SerializeField]
    private int clickTreshold;
	
	public GameObject PanelToWash;

	private Image paperToWash;
	[SerializeField] 
    

	private float greyLevel = 0.2f;
    void Start()
    {
		//paperToWash = PanelToWash.GetComponent<Image>();
		//paperToWash.color = new Color(greyLevel, greyLevel, greyLevel, 1.0f);
		//image.preserveAspect = true;
		

	}

	private void Update()
	{
		//paperToWash.color = new Color(greyLevel, greyLevel, greyLevel, 1.0f);
	}

	public void WashPaper()
	{
		//StartCoroutine(refreshButton());
		image.sprite = MinigameSprites[tapCounter];
		tapCounter++;
		//greyLevel+= 0.1f;
		
		
		
	}

	public void ResetMiniGame()
	{
		tapCounter = 0;
	}

    public bool IsMinigameFinished()
    {
        return tapCounter >= clickTreshold;
    }
	private IEnumerator refreshButton()
	{
		image.sprite = MinigameSprites[1];
		yield return new WaitForSeconds(0.3f);
		image.sprite = MinigameSprites[0];
	}
}
