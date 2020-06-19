using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantieParticle : MonoBehaviour
{
    public GameObject starParticle;
    public Vector3 spawnLocation;

   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject SpawnLocation = (GameObject) Instantiate(starParticle, spawnLocation, Quaternion.Euler(90,0,0));
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
