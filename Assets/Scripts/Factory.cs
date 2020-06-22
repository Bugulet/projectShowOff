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
	private GameObject MiniGameContainerPanel;
    [SerializeField]
    private int scoreAmount = 1;

    [SerializeField]
    private int materialAmount = 1;

    [SerializeField]
    private int factoryType;

    private ScoreCounter scoreCounter;
    private MaterialCounter materialCounter;
    private GameObject recycleButton;

    [SerializeField]
    private GameObject MiniGameObject;

    [SerializeField]
    private GameObject textFeedback;

    private MinigameInterface MiniGame;

    private void Start()
    {
        recycleButton = transform.GetChild(1).gameObject;
        scoreCounter = FindObjectOfType<ScoreCounter>();
        materialCounter = FindObjectOfType<MaterialCounter>();
        MiniGame = MiniGameObject.GetComponent<MinigameInterface>();
    }

    // Update is called once per frame
    private void Update()
    {
		//if bin is not full
		if (Globals.isGameOver == false)
		{
			if (itemsRecycled < recycledItemsThreshold)
			{
				//if an item collided with the factory and the finger was released
				if (itemToBeRecycled != null && itemToBeRecycled.GetComponent<Lean.Touch.LeanSelectable>().IsSelected == false)
				{
					if (CompareWithReceivedItem(itemToBeRecycled))
					{
						//set it to innactive but dont destroy it, used for regenerating the item afterwards
						scoreCounter.IncreaseTheScore(scoreAmount);
						itemToBeRecycled.gameObject.SetActive(false);
						itemsRecycled++;
						Globals.ItemsRecycled++;
						FindObjectOfType<SoundEffects>().PlayGoodSound();

					}
					else
					{
						FindObjectOfType<SoundEffects>().PlayBadSound();
						scoreCounter.DecreaseTheScore(scoreAmount);
					}
					itemToBeRecycled = null;
				}
			}
			//if its full just enable the button for recycling
			else
			{
				if (MiniGame.IsMinigameFinished())
				{
					///recycleButton.SetActive(true);

					//MiniGameObject.SetActive(false);
					//MiniGameContainerPanel.SetActive(false);

				}
				else
				{
					MiniGameContainerPanel.SetActive(true);
					MiniGameObject.SetActive(true);
				}
			}
		}
    }

    public void AddScoreAndMaterials()
    {
        scoreCounter.IncreaseTheScore(scoreAmount*5);
        materialCounter.IncreaseMaterials(materialAmount);
        itemsRecycled = 0;
        //recycleButton.SetActive(false);
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
            if (itemsRecycled < recycledItemsThreshold)
            {
                itemToBeRecycled = collision.gameObject.GetComponent<RecycleItem>();
            }
            else
            {
                //TODO: add factory feedback
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "recycleItem")
        {
            itemToBeRecycled = null;
        }
    }
}
