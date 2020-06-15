using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardScript : MonoBehaviour
{
    [SerializeField]
    Scoreboard scoreboard;

    [SerializeField]
    Text text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddCharacter(string param)
    {
        text.text += param;
        scoreboard.SetSessionName(text.text);
    }

}
