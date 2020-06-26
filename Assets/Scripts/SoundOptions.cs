using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour
{
	private bool isSoundUnMuted = true;
	public Sprite soundOff;
	public Sprite soundOn;
	private Image buttonImage;
	private void Start()
	{
		buttonImage = this.gameObject.GetComponent<Image>();
	}
	public void MuteAllSounds()
	{
		isSoundUnMuted = !isSoundUnMuted;
		if (!isSoundUnMuted)
		{
			AudioListener.volume = 0;
			buttonImage.sprite = soundOff ;

		}
		else
		{
			AudioListener.volume = 1;
			buttonImage.sprite = soundOn;
		}
	}
	
	
}
