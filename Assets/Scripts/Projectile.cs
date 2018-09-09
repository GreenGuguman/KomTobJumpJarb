using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

    public float speed, damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveProjectile();
	}

    public void MoveProjectile()
    {
        GetComponent<Rigidbody2D>().transform.Translate
        (Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker_TypeA attacker = collision.gameObject.GetComponent<Attacker_TypeA>();
        Health health = collision.GetComponent<Health>();

        if (attacker && health)
        {
            health.DamageReceived(damage);
            Destroy(gameObject);
        }

    }

}
