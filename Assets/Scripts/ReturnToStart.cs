using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToStart : MonoBehaviour
{

    [SerializeField]
    [Range(0, 60)]
    [Tooltip("Time before the game resets to main menu, 0 to never reset")]
    private float ResetTime=0;
    private float counter;


    // Start is called before the first frame update
    void Start()
    {
        Lean.Touch.LeanTouch.OnFingerDown += LeanTouch_OnFingerDown;
    }

    //event function
    private void LeanTouch_OnFingerDown(Lean.Touch.LeanFinger obj)
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        
        if(ResetTime>0 && counter >= ResetTime)
        {
            SceneChanger.GoToStart();
        }
    }
}
