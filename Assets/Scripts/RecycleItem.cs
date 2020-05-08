using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecycleItem : MonoBehaviour
{
	[SerializeField]
	public int itemType { get; set; }
    


    void Start()
    {
        instantiateSprite();
    }

    private void OnEnable()
    {
        instantiateSprite();
    }


    private void instantiateSprite()
    {
        itemType = Random.Range(0, 3);

        if (itemType == 0)
        {
            gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/organic/" + Random.Range(0, 1));
        }
        if (itemType == 1)
        {
            gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/paper/" + Random.Range(0, 1));
        }
        if (itemType == 2)
        {
            gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/metal/" + Random.Range(0, 1));
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
