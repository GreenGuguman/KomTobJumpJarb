using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker_TypeA))]
public class Red_bird : MonoBehaviour {

    //public string animationName = "";
    private Animator targetAnimation;
    private Attacker_TypeA attackerA;

    // Use this for initialization
    void Start () {
        targetAnimation = GetComponent<Animator>();
        attackerA = GetComponent<Attacker_TypeA>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("some thing happen");
        GameObject obj = collider.gameObject;

        //Only if it collide with defender
        if (!obj.GetComponent<Defender_TypeA>())
        {
            return;
        }
        else
        {
            targetAnimation.SetBool("isAttacking", true);
            attackerA.Attack(obj);
        }

        //Debug.Log("Brown_bird Collided with " + collider);
        if (obj.GetComponent<Cannon_ball>())
        {
            //triger an animation when collide with that obj
            targetAnimation.SetTrigger("isAttacked");
        }
    }

}
