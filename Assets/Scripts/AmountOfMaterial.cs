using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class AmountOfMaterial : MonoBehaviour {

    public enum Status {SUCCESS, FAILURE};

    private Text txtAmount;
    //only use text to display not storing
    //only do translation to text not from text

    private int currentAmount = 6;

	// Use this for initialization
	void Start () {
        txtAmount = GetComponent<Text>();
        // when we only look for component on our selft obj
        UpDateAmount();
	}

    void Update()
    {
        //print(currentAmount);
    }

    public void AddMaterial(int amount)
    {
        currentAmount += amount;
        UpDateAmount();
    }

    public Status UseMaterial(int amount)
    {
        if (currentAmount >= amount)
        {
            currentAmount -= amount;
            UpDateAmount();
            return Status.SUCCESS;
        }
            return Status.FAILURE;
            // you don't need else statement here        
    }

    void UpDateAmount()
    {
        txtAmount.text = currentAmount.ToString();
    }

}
