
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AnimateUi : MonoBehaviour
{
	

	
	private Image image;

	public float endAnimationTime;
	public Sprite[] SpriteSheet;

	private void Awake()
	{
		

		image = GetComponent<Image>();
		image.preserveAspect = true;
	}

	public IEnumerator StartAnimation()
	{
		var currentSpriteIndex = 0;

		while (true)
		{
			image.sprite = SpriteSheet[currentSpriteIndex];

			yield return new WaitForSeconds(0.07f);

			currentSpriteIndex = (currentSpriteIndex + 1) % SpriteSheet.Length;

			StartCoroutine(CloseAnimation());
		}
	}
	public void PlayAnimation()
	{
		this.gameObject.SetActive(true);
		StartCoroutine(StartAnimation());

	}

	public IEnumerator CloseAnimation()
	{
		yield return new WaitForSeconds(endAnimationTime);

		this.gameObject.SetActive(false);
	}
}
