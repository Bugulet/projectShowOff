using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        if (trashItem != null && !trashItem.GetComponent<Lean.Touch.LeanSelectable>().IsSelected)
        {
            trashItem.transform.localPosition = new Vector3(0, 0, 0);
        }

        if (trashItem.GetComponent<Lean.Touch.LeanSelectable>().IsSelected)
        {
            Globals.isGrabbingTrash = true;
        }

        if (Lean.Touch.LeanTouch.Fingers.Count == 0)
        {
            Globals.isGrabbingTrash = false;
        }
		
		if(Globals.ItemsRecycled >= 4)
		{
			print(Globals.ItemsRecycled);
		}
		
    }
}
