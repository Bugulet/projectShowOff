using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject[] EnvironmentTrash;

    [Tooltip("Required items before the minigame is starting")]
    public int recycledItemsThreshold = 3;

    [HideInInspector]
    public int itemsRecycled;

    [HideInInspector]
    public RecycleItem itemToBeRecycled;

    [SerializeField]
    private int scoreAmount = 1;

    [SerializeField]
	private int materialAmount = 1;

    [SerializeField]
    private int factoryType;

    private ScoreCounter scoreCounter;
    private MaterialCounter materialCounter;
    private GameObject recycleButton;

	public GameObject paperMiniGameObject;
	private PaperFactoryMiniGame paperMiniGame;

	void Start()
	{
        recycleButton = transform.GetChild(1).gameObject;
		scoreCounter = FindObjectOfType<ScoreCounter>();
		materialCounter = FindObjectOfType<MaterialCounter>();
		paperMiniGame = paperMiniGameObject.GetComponent<PaperFactoryMiniGame>();
	}
    
    // Update is called once per frame
    private void Update()
    {
        //if bin is not full
        if (itemsRecycled < recycledItemsThreshold)
        {
            //if an item collided with the factory and the finger was released
            if (itemToBeRecycled != null && itemToBeRecycled.GetComponent<Lean.Touch.LeanSelectable>().IsSelected == false)
            {
                if (CompareWithReceivedItem(itemToBeRecycled))
                {
                    //set it to innactive but dont destroy it, used for regenerating the item afterwards
                    itemToBeRecycled.gameObject.SetActive(false);
                    itemsRecycled++;
					
                }
                else
                {
                    scoreCounter.DecreaseTheScore(scoreAmount);
                }
                itemToBeRecycled = null;
            }
        }
        //if its full just enable the button for recycling
        else
        {
			if(factoryType == 1)
			{
				
				if (paperMiniGame.IsPaperWashed())
				{
					recycleButton.SetActive(true);
					
					paperMiniGameObject.SetActive(false);
					
				}
				else
				{
					paperMiniGame.gameObject.SetActive(true);
				}
			}
			else
			{
				recycleButton.SetActive(true);
			}
           
        }
    }

    public void AddScoreAndMaterials()
    {
		scoreCounter.IncreaseTheScore(scoreAmount);
		materialCounter.IncreaseMaterials(materialAmount);
		itemsRecycled = 0;
		recycleButton.SetActive(false);
    }

    public bool CompareWithReceivedItem(RecycleItem recycleItem)
    {
        ///This also works as a shortcut
        return recycleItem.itemType == factoryType;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "recycleItem")
        {
            itemToBeRecycled = collision.gameObject.GetComponent<RecycleItem>();
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "recycleItem")
        {
            itemToBeRecycled = collision.gameObject.GetComponent<RecycleItem>();
          
        }
    }

}
