using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker_TypeA : MonoBehaviour {

    //Delete this no longer need it //[Range (-1f, 1.5f)]
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator TargetAnimation;

    [Tooltip ("The delay in second before this type of enemy will be spawned")]
    public float spawnEverySecond;
    public GameObject TargetObject;

	// Use this for initialization
	void Start () {
        TargetAnimation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        AttackerFly();
    }

    void AttackerFly()
    {
        TargetObject.transform.Translate(Vector3.down * currentSpeed * Time.deltaTime);
    }

    void Adding_rigid_body()
    {
        Rigidbody2D my2DRigidBody = gameObject.AddComponent<Rigidbody2D>();
        my2DRigidBody.isKinematic = true;
        my2DRigidBody.gravityScale = 0;
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //called from the animator at the time of actual blow
    void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DamageReceived(damage);
                //Debug.Log(health.health);
            }
        }

    }

    public void Attack (GameObject obj)
    {
        currentTarget = obj;
        //Debug.Log(currentTarget.name);
    }

    void CurrentTargetCheck()
    {
        if (!currentTarget)
        {
            TargetAnimation.SetBool("isAttacking", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TargetAnimation.SetBool("isAttacking", false);
    }

}
