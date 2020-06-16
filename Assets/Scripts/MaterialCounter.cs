using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialCounter : MonoBehaviour
{
	public int Materials { get; private set; }
	void Start()
    {
		Materials = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.F))
		{
			IncreaseMaterials(1);
		}
		print(Materials);
    }
	public void IncreaseMaterials(int materialAmount)
	{
		Materials += materialAmount;
	
	}
	public void DecreaseMaterials(int materialAmount)
	{
		Materials -= materialAmount;	
	}
}
