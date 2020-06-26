﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaterialChanger : MonoBehaviour
{
    private ScoreCounter counter;

    [SerializeField]
    Material swapMaterial;

    // Start is called before the first frame update
    void Start()
    {
        counter = FindObjectOfType<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter.Score > 0 && Mathf.Max(counter.Score - 1,0) < transform.childCount)
        {
			
            changeHexagon objectTween = transform.GetChild(counter.Score - 1).GetComponent<changeHexagon>();
			if (objectTween != null)
			{
				objectTween.StartMorphing(swapMaterial);
			}
        }
        

    }
}
