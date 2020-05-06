using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
	[SerializeField]
	private int factoryType;
	private RecycleItem itemToBeRecycled;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (itemToBeRecycled != null && CompareWithReceivedItem(itemToBeRecycled))
		{
			
			Destroy(itemToBeRecycled.gameObject);
			Debug.Log("Distrus");
		}
    }
	bool CompareWithReceivedItem(RecycleItem recycleItem)
	{
		if(recycleItem.itemType == factoryType)
		{
			Debug.Log("adevarat");
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
