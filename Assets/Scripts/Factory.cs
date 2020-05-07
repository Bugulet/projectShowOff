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
	private int scoreAmount=1;
	
    void Start()
    {
		scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemToBeRecycled != null && itemToBeRecycled.GetComponent<Lean.Touch.LeanSelectable>().IsSelected == false)
		{
            if (CompareWithReceivedItem(itemToBeRecycled))
            {
                scoreCounter.IncreaseTheScore(scoreAmount);

                //set it to innactive but dont destroy it, used for regenerating the item afterwards
                itemToBeRecycled.gameObject.SetActive(false);
                
                Debug.Log("score: " + scoreCounter.Score);
            }
            else
            {
                scoreCounter.DecreaseTheScore(scoreAmount);
            }

            //clear reference
            itemToBeRecycled = null;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "recycleItem")
        {
            itemToBeRecycled = collision.gameObject.GetComponent<RecycleItem>();
            Debug.Log("Collided");
        }
    }

    void OnCollisionEnter(Collision collision)
	{
		
		if (collision.gameObject.tag == "recycleItem")
		{
			itemToBeRecycled = collision.gameObject.GetComponent<RecycleItem>();
			Debug.Log("Collided");
		}
	}
	
}
