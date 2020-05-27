using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeUntilDestroy : MonoBehaviour
{
    [SerializeField]
    private float rescaleSpeed=1f;
    private float currentScale=1f;
    
    // Update is called once per frame
    void Update()
    {
        if (currentScale > 0)
        {
            currentScale -= rescaleSpeed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

        transform.localScale = new Vector2(currentScale, currentScale);

    }
}
