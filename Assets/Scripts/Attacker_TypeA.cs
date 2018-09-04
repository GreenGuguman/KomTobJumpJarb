using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker_TypeA : MonoBehaviour {

    //Delete this no longer need it //[Range (-1f, 1.5f)]
    private float currentSpeed;
    private GameObject currentTarget;

    public float currentOpponentHealth = 100;
    public GameObject TargetObject;
    public Animator TargetAnimation;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currentOpponentHealth);
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
    void StrikeCurrentTraget(float damage)
    {
        currentOpponentHealth = currentOpponentHealth - damage;
        Debug.Log(name + " had dealt " + damage);
    }

    public void Attack (GameObject obj)
    {
        currentTarget = obj;
    }

}
