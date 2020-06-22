using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
	private MaterialCounter materialCounter;

	public GameObject MacroUpgradeButton;
	public GameObject CloseUpgradeButton;

	public List<GameObject> ObjectUpgradeButtons;
	private bool[] buttonIsHidden; 

	public GameObject TreesForEmptySpaceUpgrade;
	public GameObject BuildingCreatedAfterUpgrade;
	public GameObject BuildingCreatedAfterUpgrade2;
	public GameObject Cornfield;
	public GameObject Hospital;
	public GameObject Macandra;
	public GameObject RedBlocks;
	public GameObject BadTiles;
	public GameObject CleanTiles;
	public GameObject CleanHouses;
	public GameObject TrashedHouses;

	

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
		if (Globals.isGameOver == false)
		{
			if (materialCounter.Materials >= 2 && CloseUpgradeButton.activeSelf == false)
			{
				EnableUpgradeButton();
			}

			if (timer > 0)
			{

				timer += Time.deltaTime;
			}
			if (timer > 4)
			{
				GoToEnd();
			}
		}
		/*if(gameTimer.TimerCount < 0)
		{
			SceneChanger.GoToEnd();
		}*/
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
		DisableUpgradeButton();
		CloseUpgradeButton.SetActive(true);
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
	public void CloseUpgrades()
	{
		DisableAllButtons();
		if(materialCounter.Materials >= 2)
		{
			MacroUpgradeButton.SetActive(true);
		}
		
		CloseUpgradeButton.SetActive(false);
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
		CloseUpgradeButton.SetActive(false);
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
		CloseUpgradeButton.SetActive(false);
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
		CloseUpgradeButton.SetActive(false);
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
		CloseUpgradeButton.SetActive(false);
	}
	public void CreateCornfield()
	{
		if (MacroUpgradeButton == null)
		{
			return;
		}
		Cornfield.SetActive(false);
		BadTiles.SetActive(false);
		TrashedHouses.SetActive(false);
		CleanTiles.SetActive(true);
		CleanHouses.SetActive(true);
		materialCounter.DecreaseMaterials(2);

		DisableAndRemoveButtonAtIndex(4);
		DisableAllButtons();
		DisableUpgradeButton();
	}
	public void CreateMacandra()
	{
		if (MacroUpgradeButton == null)
		{
			return;
		}
		Macandra.SetActive(true);
		materialCounter.DecreaseMaterials(2);

		DisableAndRemoveButtonAtIndex(6);
		DisableAllButtons();
		DisableUpgradeButton();
		CloseUpgradeButton.SetActive(false);
	}
	public void CreateBlocks()
	{
		if (MacroUpgradeButton == null)
		{
			return;
		}
		RedBlocks.SetActive(true);
		materialCounter.DecreaseMaterials(2);

		DisableAndRemoveButtonAtIndex(7);
		DisableAllButtons();
		DisableUpgradeButton();
		CloseUpgradeButton.SetActive(false);
	}
	

}
