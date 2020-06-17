using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperFactoryMiniGame : MonoBehaviour , MinigameInterface
{
	private int tapCounter = 0;

	public Image image;
	public Sprite[] MinigameSprites;

    [Tooltip("The times you click to recycle.")]
    [Range(1, 10)]
    [SerializeField]
    private int clickTreshold;
	
	public GameObject PanelToWash;
	[SerializeField]
	private GameObject tutorial;
	
	private float timeBeforeTutorialAppears;
	[SerializeField]
	private float EditorTimeBeforeTutorialAppears;
	private Image paperToWash;

	private void Update()
	{
		StartCoroutine(StartTutorial());
	}

	public void WashPaper()
	{
		image.sprite = MinigameSprites[tapCounter];
		tapCounter++;
	}

	public void ResetMiniGame()
	{
		tapCounter = 0;
		tutorial.SetActive(false);
	}

    public bool IsMinigameFinished()
    {
        return tapCounter >= clickTreshold;
    }
	private IEnumerator refreshButton()
	{
		image.sprite = MinigameSprites[1];
		yield return new WaitForSeconds(0.3f);
		image.sprite = MinigameSprites[0];
	}
	private IEnumerator StartTutorial()
	{
		//timeBeforeTutorialAppears = EditorTimeBeforeTutorialAppears;
		yield return new WaitForSeconds(EditorTimeBeforeTutorialAppears);
		tutorial.SetActive(true);
	}
}
