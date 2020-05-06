using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashSpawner : MonoBehaviour
{
    GameObject trashItem;

    // Start is called before the first frame update
    void Start()
    {
        trashItem = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!trashItem.GetComponent<Lean.Touch.LeanSelectable>().IsSelected)
        {
            trashItem.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
