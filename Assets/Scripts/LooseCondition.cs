using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCondition : MonoBehaviour {

    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (!obj.GetComponentInChildren<Attacker_TypeA>())
        {
            return;
        }
        else
        {
            //levelManager.FadeToNextLevel(); // not work for now
            levelManager.LoadLevel("Level_Lose");
        }

    }

}
