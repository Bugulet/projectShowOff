using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganicMinigame : MonoBehaviour , MinigameInterface
{
    private GameObject pistonObject;
    private GameObject trashObject;
	public GameObject AnimationPanel;
	[SerializeField]
	private GameObject tutorial;

    [SerializeField]
    private int scoreThreshold = 3;
	
    private int score = 0;

    private Vector3 smashedScale;

	private float timeBeforeTutorialStarts;
	[SerializeField]
	private float EditorTimeBeforeTutorialStarts;
	[SerializeField]
	private Factory PlasticFactory;
	[SerializeField]
	private AnimateUi PlasticAnimation;
	[SerializeField]
	private GameObject PlasticMinigameContainer;

	// Start is called before the first frame update
	void Start()
    {
        pistonObject = transform.GetChild(0).gameObject;
        trashObject= transform.GetChild(1).gameObject;

        smashedScale = trashObject.transform.localScale;
    }
    
    public void ResetMiniGame()
    {
        score = 0;
        pistonObject.transform.localPosition = new Vector3(0,80 , 0);
        trashObject.transform.localScale = new Vector3(smashedScale.x,smashedScale.y,smashedScale.y);
		tutorial.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
		
		if (pistonObject.GetComponent<CompareCollision>().HasCollidedWithObject())
        {
			
			score++;
            trashObject.transform.localScale = new Vector3(trashObject.transform.localScale.x, trashObject.transform.localScale.y/1.2f);
			
        }

        pistonObject.transform.localPosition = new Vector3(0, Mathf.Max(Mathf.Min(80, pistonObject.transform.localPosition.y), 30), 0);
		StartCoroutine(StartTutorial());
		if (IsMinigameFinished())
		{
			PlasticFactory.AddScoreAndMaterials();
			ResetMiniGame();

			PlasticAnimation.PlayAnimation();
			this.gameObject.SetActive(false);
			PlasticMinigameContainer.SetActive(false);
		}
	}


    public bool IsMinigameFinished()
    {
        if (score >= scoreThreshold)
        {
			
			return true;
			
        }
        else
        {
            return false;
        }
    }
	private IEnumerator StartTutorial()
	{
		//timeBeforeTutorialStarts = EditorTimeBeforeTutorialStarts;
		yield return new WaitForSeconds(EditorTimeBeforeTutorialStarts);
		tutorial.SetActive(true);
	}
    
}
