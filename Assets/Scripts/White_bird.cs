using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker_TypeA))]
public class White_bird : MonoBehaviour
{

    //public string animationName = "";
    private Animator targetAnimation;
    private Attacker_TypeA attackerA;

    // Use this for initialization
    void Start()
    {
        targetAnimation = GetComponent<Animator>();
        attackerA = GetComponent<Attacker_TypeA>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if (!obj.GetComponent<Defender_TypeA>())
        {
            return;
        }
        else
        {
            targetAnimation.SetBool("isAttacking", true);
            attackerA.Attack(obj);
        }

        if (obj.GetComponent<Cannon_ball>())
        {
            targetAnimation.SetTrigger("isAttacked");
        }
    }

}
