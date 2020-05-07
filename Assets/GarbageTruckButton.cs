using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageTruckButton : MonoBehaviour
{
    [SerializeField]
    GameObject trashPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplenishTrash()
    {
        for (int i = 0; i < trashPanel.transform.childCount; i++)
        {

            trashPanel.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
