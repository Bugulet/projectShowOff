using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
	public Factory PlasticFactory;
	public Factory PaperFactory;
	public Factory OrganicFactory;

	[SerializeField]
	private GameObject EnvironmentTrash;
	[SerializeField]
	private GameObject Trees;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		if(PlasticFactory.itemsRecycled == 2 || OrganicFactory.itemsRecycled == 2 || PaperFactory.itemsRecycled == 2)
		{
			EnvironmentTrash.SetActive(false);
		}
		if(PaperFactory.itemsRecycled == 2)
		{
			Trees.SetActive(true);
		}
		print("PaperFactory: " + PaperFactory.itemsRecycled);
	}
}
