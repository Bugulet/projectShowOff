using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameDisplayScore : MonoBehaviour
{
	public Text scoreText;
	
    // Start is called before the first frame update
    void Start()
    {
		scoreText.text = PlayerPrefs.GetInt("score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.SetInt("score", Random.Range(0, 150));
            scoreText.text = PlayerPrefs.GetInt("score").ToString();
        }
    }
}
