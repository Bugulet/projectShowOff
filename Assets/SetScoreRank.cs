using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScoreRank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = (transform.GetSiblingIndex()+1).ToString();
    }
}
