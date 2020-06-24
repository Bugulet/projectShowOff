using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackColorChanger : MonoBehaviour
{
    private Scoreboard scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreboard.GetFeedback() < transform.GetSiblingIndex() + 1)
        {
            GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            GetComponent<Image>().color = new Color(1,1,1);
        }
    }
}
