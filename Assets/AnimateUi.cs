
using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AnimateUi : MonoBehaviour
{
	[SerializeField] private SpriteAtlas spriteSheet;

	private Sprite[] sprites;
	private Image image;

	private void Awake()
	{
		sprites = new Sprite[spriteSheet.spriteCount];
		spriteSheet.GetSprites(sprites);

		image = GetComponent<Image>();
		image.preserveAspect = true;
	}

	public IEnumerator StartAnimation()
	{
		var currentSpriteIndex = 0;

		while (true)
		{
			image.sprite = sprites[currentSpriteIndex];

			yield return new WaitForSecondsRealtime(0.1f);

			currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;

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
		yield return new WaitForSeconds(2.0f);

		this.gameObject.SetActive(false);
	}
}
