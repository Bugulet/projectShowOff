using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeButtonFill : MonoBehaviour
{
	public Image image;
	private MaterialCounter materialCounter;


	private int materialThreshold = 2;
    void Start()
    {
		materialCounter = FindObjectOfType<MaterialCounter>();
    }

    // Update is called once per frame
    void Update()
    {
		image.fillAmount = (float)materialCounter.Materials / materialThreshold;
		print(image.fillAmount);
    }
}
