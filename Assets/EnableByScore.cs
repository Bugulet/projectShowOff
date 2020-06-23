using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableByScore : MonoBehaviour
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
        if(counter.Score>0 && counter.Score-1<transform.childCount && transform.GetChild(counter.Score - 1).gameObject.activeSelf == false)
        {
            transform.GetChild(counter.Score - 1).gameObject.SetActive(true);
        }
    }
}
