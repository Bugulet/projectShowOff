
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

    int currentSpriteIndex = 0;

    private void Awake()
	{
		image = GetComponent<Image>();
		image.preserveAspect = true;
	}

    private void Update()
    {
        image.sprite = SpriteSheet[currentSpriteIndex];
    }

    public IEnumerator StartAnimation()
	{
        StartCoroutine(CloseAnimation());
        while (true)
		{
			yield return new WaitForSeconds(0.03f);
			currentSpriteIndex = (currentSpriteIndex + 1) % (SpriteSheet.Length -1);
            print("picture size "+SpriteSheet[currentSpriteIndex].texture.width);
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
