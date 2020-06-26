using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonGrid : MonoBehaviour
{
    [SerializeField]
    private Material[] materials=new Material[4];
    private int currentMaterial = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PreviousMaterial()
    {
        currentMaterial--;
        if (currentMaterial < 0)
            currentMaterial = materials.Length - 1;
        changeMaterial();
    }

    public void NextMaterial()
    {
        
        currentMaterial++;
        if (currentMaterial > materials.Length-1)
            currentMaterial = 0;
        changeMaterial();
    }

    private void changeMaterial()
    {
        GetComponent<Renderer>().material = materials[currentMaterial];
    }
}
