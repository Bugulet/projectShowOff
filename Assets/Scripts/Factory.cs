using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
	[SerializeField]
	private int factoryType;
	private RecycleItem itemToBeRecycled;

	private ScoreCounter scoreCounter;
	[SerializeField]
	private int scoreAmount;
	
    void Start()
    {
		scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
		if (itemToBeRecycled != null && CompareWithReceivedItem(itemToBeRecycled))
		{
			scoreCounter.IncreaseTheScore(scoreAmount);
			Destroy(itemToBeRecycled.gameObject);
			Debug.Log(scoreCounter.Score);
		}
		else
		{
			scoreCounter.DecreaseTheScore(scoreAmount);
		}
    }
	bool CompareWithReceivedItem(RecycleItem recycleItem)
	{
		if(recycleItem.itemType == factoryType)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Collided");
		if (collision.gameObject.tag == "recycleItem")
		{
			itemToBeRecycled = collision.gameObject.GetComponent<RecycleItem>();
			Debug.Log("Collided");
		}
	}
	
}
