using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareCollision : MonoBehaviour
{

    private GameObject collidedObject;

    private bool collidedWithObject = false;
    
    // Update is called once per frame
    void Update()
    {
        if (collidedObject != null && collidedObject.CompareTag("smashedObject"))
        {
            print("collided with proper object");
            collidedWithObject = true;
            collidedObject = null;
        }
    }

    public bool HasCollidedWithObject()
    {
        if (collidedWithObject == true)
        {
            collidedWithObject = false;
            return true;
        }
        else return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidedObject = collision.gameObject;
    }

}
