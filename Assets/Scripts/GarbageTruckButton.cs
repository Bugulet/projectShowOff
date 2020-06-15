using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarbageTruckButton : MonoBehaviour
{
    [SerializeField]
    private GameObject trashPanel;

	private Image fillBar;

    [SerializeField]
    [Range(0, 14)]
    public float rechargeTime;
    private float timeRemaining;
    private Text innerText;

    // Start is called before the first frame update
    private void Start()
    {
		fillBar = this.GetComponent<Image>();
        innerText = transform.GetChild(0).gameObject.GetComponent<Text>();
        timeRemaining = rechargeTime;
    }

    // Update is called once per frame
    private void Update()
    {
        timeRemaining += Time.deltaTime;
        if (timeRemaining < rechargeTime)
        {
            innerText.text = "Time left: " + (int)(rechargeTime - timeRemaining);
        }
        else
        {
            innerText.text = "Ready!";
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ForceRefreshTrash();
        }
		fillBar.fillAmount = timeRemaining / rechargeTime;
    }

    private void ReplenishTrash()
    {
        for (int i = 0; i < trashPanel.transform.childCount; i++)
        {
            trashPanel.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        timeRemaining = 0;
    }

    public void ForceRefreshTrash()
    {
        for (int i = 0; i < trashPanel.transform.childCount; i++)
        {
            trashPanel.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            trashPanel.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void RechargeTruck()
    {
        if (timeRemaining < rechargeTime)
        {
            StartCoroutine(switchColor());
        }

        if (timeRemaining > rechargeTime)
        {
            ReplenishTrash();
        }
    }

    private IEnumerator switchColor()
    {
        innerText.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        innerText.color = Color.white;

    }
}