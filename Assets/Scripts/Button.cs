using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private Button[] buttonArray;
    //private Animator animator;

	// Use this for initialization
	void Start () {
        buttonArray = FindObjectsOfType<Button>();
        //animator = FindObjectOfType<Animator>();
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

}
