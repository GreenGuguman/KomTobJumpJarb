using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private Text costTXT;

    private Button[] buttonArray;
    //private Animator animator;

	// Use this for initialization
	void Start () {
        CheckingNeededObject();
	}

    private void OnMouseDown()
    {
        foreach(Button thisButton in buttonArray)
        {
            thisButton.GetComponentInChildren<SpriteRenderer>().color = Color.gray;
            //animator.SetTrigger("Idle");
        }

        GetComponentInChildren<SpriteRenderer>().color = Color.white;
        //animator.SetTrigger("Zoom");

        selectedDefender = defenderPrefab;



    }

    void CheckingNeededObject()
    {
        buttonArray = FindObjectsOfType<Button>();
        costTXT = GetComponentInChildren<Text>();

        if (costTXT)
        {
            costTXT.text = defenderPrefab.GetComponent<Defender_TypeA>().materialCost.ToString();
        }
        else
        {
            Debug.LogWarning("This " + name + " has no material cost");
        }
        
    }

}
