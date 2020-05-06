using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleItem : MonoBehaviour
{
	[SerializeField]
	public int itemType { get; set; }
	public int potentialItemType { get; private set; }
    void Start()
    {
		
		potentialItemType = Random.Range(0, 3);
		itemType = potentialItemType;
		Debug.Log(itemType);
		
	}

    // Update is called once per frame
    void Update()
    {

		if (itemType == 0)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.green);
		}
		if (itemType == 1)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.blue);
		}
		if (itemType == 2)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
		}
	}
}
