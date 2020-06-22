using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimesUpPanelOpener : MonoBehaviour
{
	[SerializeField]
	private GameObject ConfirmPanel;
  
	public void OpenPanel()
	{
		ConfirmPanel.SetActive(true);
	}
}
