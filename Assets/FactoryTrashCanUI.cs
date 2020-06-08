using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryTrashCanUI : MonoBehaviour
{
    Vector2 startPosition;

    Factory parentFactory;

    Transform blackMask;

    float spriteHeight;

    // Start is called before the first frame update
    void Start()
    {
        spriteHeight = GetComponent<RectTransform>().rect.size.y;

        blackMask = transform.GetChild(0);
        startPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);
        parentFactory= transform.parent.gameObject.GetComponent<Factory>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(parentFactory.itemsRecycled);
        blackMask.localPosition = new Vector3(0, (spriteHeight / parentFactory.recycledItemsThreshold) * parentFactory.itemsRecycled);
    }
}
