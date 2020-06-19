﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToTarget : MonoBehaviour
{
    public Transform targetPoint;
    public float moveSpeed;

    public Animator _starAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _starAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            print("works");
            //_starAnimation.Play();
            _starAnimator.SetBool("triggered",true);
            Destroy(gameObject);
            //star.transform.localScale = new Vector2(2,2);
            //star.rectTransform.sizeDelta = new Vector2(width, height);
        }
    }
}
