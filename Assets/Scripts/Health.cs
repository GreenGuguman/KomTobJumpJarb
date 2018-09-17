using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health=100;

    public GameObject thisParentObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DamageReceived(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //need to destroy parent obj
            Destroy(thisParentObject);
            print("this one is dead");
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
