using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperFactoryMiniGame : MonoBehaviour
{
	private int tapCounter = 0;

    [Tooltip("The times you click to recycle.")]
    [Range(1, 10)]
    [SerializeField]
    private int clickTreshold;
	
	public GameObject PanelToWash;

	private Image paperToWash;
	[SerializeField] 
    

	private float greyLevel = 0.2f;
    void Start()
    {
		paperToWash = PanelToWash.GetComponent<Image>();
		paperToWash.color = new Color(greyLevel, greyLevel, greyLevel, 1.0f);

	}
	private void Update()
	{
		paperToWash.color = new Color(greyLevel, greyLevel, greyLevel, 1.0f);
	}
	public void WashPaper()
	{
		tapCounter++;
		greyLevel+= 0.1f;
	}
	public bool IsPaperWashed()
	{
        return tapCounter >= clickTreshold;
	}
	public void ResetMiniGame()
	{
		greyLevel = 0.2f;
		paperToWash.color = new Color(greyLevel, greyLevel, greyLevel, 1.0f);
		tapCounter = 0;
		
	}
}
