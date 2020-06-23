﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecycleItem : MonoBehaviour
{
	[SerializeField]
	public int itemType { get; set; }
    


    void Start()
    {
        instantiateSprite();
    }

    private void OnEnable()
    {
		Globals.ItemsRecycled--;
        instantiateSprite();
    }


	private void instantiateSprite()
	{
		itemType = Random.Range(0, 3);

		if (itemType == 0)
		{
			gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/organic/" + Random.Range(0, 8));
		}
		if (itemType == 1)
		{
			gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/plastic/" + Random.Range(0, 8));
		}
		if (itemType == 2)
		{
			gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/metal/" + Random.Range(0, 8));
		}

	}
    // Update is called once per frame
    void Update()
    {
		if (Globals.isGameOver == true) { this.gameObject.SetActive(false); }
		

	}
}
