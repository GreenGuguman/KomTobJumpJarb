using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders_TypeB : MonoBehaviour {

    private Animator TargetAnimation;

    void Start()
    {
        TargetAnimation = GetComponent<Animator>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TargetAnimation.SetBool("IsAttacking", false);
    }

}
