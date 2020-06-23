using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreColorChanger : MonoBehaviour
{

    private ScoreCounter counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = FindObjectOfType<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
       GetComponent<Renderer>().material.SetColor("_BaseColor", Color.Lerp(new Color(1, 0.76f, 0), new Color(1, 1, 1), (float)counter.Score / 50f));
    }
}
