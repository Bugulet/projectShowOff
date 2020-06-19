using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToTarget : MonoBehaviour
{
    public Transform targetPoint;
    public float moveSpeed;
	public Image panelToTarget;

    public Animator _starAnimator;
    // Start is called before the first frame update
    void Start()
    {
		
		targetPoint = panelToTarget.transform;
        _starAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		float distanceSpeed = Vector2.Distance(transform.position,targetPoint.transform.position);
		distanceSpeed += moveSpeed;

        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, distanceSpeed * Time.deltaTime);
		StartCoroutine(DestroyStar());
    }

    private void OnCollisionEnter(Collision other)
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
	private IEnumerator DestroyStar()
	{
		yield return new WaitForSeconds(3);
		Destroy(this.gameObject);
	}
}
