using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders_TypeB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + "Trigger Entered defender side" );
    }

}
