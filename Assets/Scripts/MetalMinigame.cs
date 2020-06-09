using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalMinigame : MonoBehaviour, MinigameInterface
{
    [SerializeField]
    private int RotationThreshold = 3;
    private GameObject wheelOne, wheelTwo;
    private bool angleIsNegative = false;

    private int rotations = 0;

    private bool isTouching = false;

    public bool IsMinigameFinished()
    {
        //TODO: change this 
        return rotations > RotationThreshold;
    }

    public void ResetGame()
    {
        rotations = 0;
        angleIsNegative = false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        wheelOne = transform.GetChild(0).gameObject;
        wheelTwo = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Lean.Touch.LeanTouch.Fingers.Count > 0 && 
            RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(),Lean.Touch.LeanTouch.Fingers[0].ScreenPosition) && Globals.isGrabbingTrash==false)
        {
            isTouching = true;
        }

        if (Lean.Touch.LeanTouch.Fingers.Count == 0)
        {
            isTouching = false;
        }

        if (isTouching)
        {
            Vector2 targetPosition = Lean.Touch.LeanTouch.Fingers[0].ScreenPosition;
            Vector2 direction = new Vector2(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y);
            float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            wheelOne.transform.eulerAngles = new Vector3(0, 0, rotation);
            wheelTwo.transform.eulerAngles = new Vector3(0, 0, -rotation);

            if (rotation > 0 && angleIsNegative == true)
            {
                angleIsNegative = false;
                rotations++;
            }

            if (rotation < 0)
            {
                angleIsNegative = true;
            }

            //print(rotations + "    " + rotation + "   " + angleIsNegative);
        }
    }

    private void LeanTouch_OnFingerUp(Lean.Touch.LeanFinger obj)
    {
        throw new System.NotImplementedException();
    }
}
