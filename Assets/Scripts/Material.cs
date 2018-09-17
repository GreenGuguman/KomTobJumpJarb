using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour {

    private AmountOfMaterial amountOfMaterial;

    // Use this for initialization
    void Start()
    {
        amountOfMaterial = FindObjectOfType<AmountOfMaterial>();
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void AddMaterial(int amount)
    {
        amountOfMaterial.AddMaterial(amount);
    }

}
