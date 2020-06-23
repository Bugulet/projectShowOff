using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeHexagon : MonoBehaviour
{
    private bool hasMorphed = false;
    private Jun_TweenRuntime objectTween;
    private Material swapMaterial;

    // Start is called before the first frame update
    private void Start()
    {
        objectTween = GetComponent<Jun_TweenRuntime>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (objectTween != null)
        {
            if (objectTween.currentTimeValue > 0.5)
            {
                print("changed material");
                GetComponent<Renderer>().material = swapMaterial;
                
            }
        }
    }

    public void StartMorphing(Material swapMaterial)
    {

        if (hasMorphed == false)
        {
            print("started morphing");
            this.swapMaterial = swapMaterial;
            hasMorphed = true;
            objectTween.Play();
        }
    }
}
