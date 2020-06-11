using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFrame : MonoBehaviour
{
    [SerializeField]
    private Transform frame;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void SetFrameToCharacter()
    {
        frame.gameObject.SetActive(true);
        frame.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}
