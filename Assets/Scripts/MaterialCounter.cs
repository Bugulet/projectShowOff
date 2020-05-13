using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialCounter : MonoBehaviour
{
    
	[SerializeField]
	public Text MaterialText;

	public int Materials { get; private set; }
	void Start()
    {
		Materials = 0;
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	private void UpdateMaterialText()
	{
		MaterialText.text = "Materials: " + Materials;
	}

	public void IncreaseMaterials(int materialAmount)
	{
		Materials += materialAmount;
		UpdateMaterialText();
	}

	public void DecreaseMaterials(int materialAmount)
	{
		Materials -= materialAmount;
		UpdateMaterialText();
	}
}
