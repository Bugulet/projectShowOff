using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
	private MaterialCounter materialCounter;

	public GameObject MacroUpgradeButton;

	public List<GameObject> ObjectUpgradeButtons;
	private bool[] buttonIsHidden; 

	public GameObject TreesForEmptySpaceUpgrade;
	public GameObject BuildingCreatedAfterUpgrade;
	public GameObject BuildingCreatedAfterUpgrade2;
	public GameObject Cornfield;
	public GameObject Hospital;

	private GarbageTruckButton garbageTruck;
	private GameTimer gameTimer;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
		materialCounter = FindObjectOfType<MaterialCounter>();
		buttonIsHidden = new bool[ObjectUpgradeButtons.Count];
		garbageTruck = FindObjectOfType<GarbageTruckButton>();
		gameTimer = FindObjectOfType<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(materialCounter.Materials >= 2)
		{
			EnableUpgradeButton();
		}

        if (timer > 0)
        {
            print("timer: " + timer);
            timer += Time.deltaTime;
        }
        if (timer > 4)
        {
            GoToEnd();
        }
		if(gameTimer.TimerCount < 0)
		{
			SceneChanger.GoToEnd();
		}
    }

	private void EnableUpgradeButton()
	{
		MacroUpgradeButton.SetActive(true);
	}

	private void DisableUpgradeButton()
	{
		MacroUpgradeButton.SetActive(false);
	}

	public void UpgradeButtonPressed()
	{
		if (MacroUpgradeButton == null)
		{
			return;
		}

		for (int i = 0; i < ObjectUpgradeButtons.Count; ++i)
		{
			if (!buttonIsHidden[i])
			{
				ObjectUpgradeButtons[i].SetActive(true);
			}
		}
	}

	private void DisableAndRemoveButtonAtIndex(int index)
	{
		ObjectUpgradeButtons[index].SetActive(false);
		buttonIsHidden[index] = true;
	}

	private void DisableAllButtons()
	{
		for (int i = 0; i < ObjectUpgradeButtons.Count; ++i)
		{
			ObjectUpgradeButtons[i].SetActive(false);
		}
	}

	public void CreateBuildingButtonPressed()
	{
		if (MacroUpgradeButton == null)
		{
			return;
		}
		BuildingCreatedAfterUpgrade.SetActive(true);
		materialCounter.DecreaseMaterials(2);
		
		DisableAndRemoveButtonAtIndex(1);
		DisableAllButtons();
		DisableUpgradeButton();
	}

	public void CreateBuildingButtonPressed2()
	{
		if (MacroUpgradeButton == null)
		{
			return;
		}
		BuildingCreatedAfterUpgrade2.SetActive(true);
		materialCounter.DecreaseMaterials(2);

		DisableAndRemoveButtonAtIndex(2);
		DisableAllButtons();
		DisableUpgradeButton();
	}


	public void CreateForestButtonPressed()
	{
       
        

        if (MacroUpgradeButton == null)
		{
			return;
		}
		TreesForEmptySpaceUpgrade.SetActive(true);
		materialCounter.DecreaseMaterials(2);

		DisableAndRemoveButtonAtIndex(3);
		DisableAllButtons();
		DisableUpgradeButton();
	}

    private void GoToEnd()
    {
        SceneChanger.GoToEnd();
    }

	public void UpgradeGarbageTruck()
	{
		if(MacroUpgradeButton == null)
		{
			return;
		}
		garbageTruck.rechargeTime = 3;
		materialCounter.DecreaseMaterials(2);

		DisableAndRemoveButtonAtIndex(0);
		DisableAllButtons();
		DisableUpgradeButton();
	}
	public void CreateHospital()
	{

		if (MacroUpgradeButton == null)
		{
			return;
		}
		Hospital.SetActive(true);
		materialCounter.DecreaseMaterials(2);

		DisableAndRemoveButtonAtIndex(5);
		DisableAllButtons();
		DisableUpgradeButton();
	}
	public void CreateCornfield()
	{
		if (MacroUpgradeButton == null)
		{
			return;
		}
		Cornfield.SetActive(true);
		materialCounter.DecreaseMaterials(2);

		DisableAndRemoveButtonAtIndex(4);
		DisableAllButtons();
		DisableUpgradeButton();
	}

}
