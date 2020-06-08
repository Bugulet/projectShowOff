using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryTrashCanUI : MonoBehaviour
{
    Vector2 startPosition;

    Factory parentFactory;

    Transform blackMask;
    Image filledBar;

    float spriteHeight,spriteWidth;

    // Start is called before the first frame update
    void Start()
    {
        filledBar = transform.GetChild(0).GetComponent<Image>();
        spriteHeight = GetComponent<RectTransform>().rect.size.y;
        spriteWidth = GetComponent<RectTransform>().rect.size.x;

        blackMask = transform.GetChild(0);
        startPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);
        parentFactory= transform.parent.gameObject.GetComponent<Factory>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(parentFactory.itemsRecycled);
        filledBar.fillAmount=(float) parentFactory.itemsRecycled / parentFactory.recycledItemsThreshold;
    }
}
