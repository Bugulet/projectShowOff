using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarbageTruckButton : MonoBehaviour
{
    [SerializeField]
    GameObject trashPanel;

    [SerializeField]
    [Range(0, 14)]
    public float rechargeTime;

    float timeRemaining;

    Text innerText;

    // Start is called before the first frame update
    void Start()
    {
        innerText= transform.GetChild(0).gameObject.GetComponent<Text>();
        timeRemaining = rechargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining += Time.deltaTime;
        if (timeRemaining < rechargeTime)
        {
            innerText.text = "Time left: " + (int)(rechargeTime- timeRemaining);
        }
        else
        {
            innerText.text = "Ready, captain!";
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ForceRefreshTrash();
        }

    }

    public void ReplenishTrash()
    {
        if (timeRemaining > rechargeTime)
        {
            for (int i = 0; i < trashPanel.transform.childCount; i++)
            {
                trashPanel.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            timeRemaining = 0;
        }
    }

    public void ForceRefreshTrash()
    {
        for (int i = 0; i < trashPanel.transform.childCount; i++)
        {
            trashPanel.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            trashPanel.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}