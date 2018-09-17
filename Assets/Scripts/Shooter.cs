using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, Gun;

    private GameObject projectileHolder;
    private Animator animator;
    private Attacker_Spawner spawnerInLane;

    // Use this for initialization
    void Start() {
        FindingObject();
        DetectEnemyInLane();
    }

    void Update()
    {
        EnemyDetector();
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileHolder.transform;
        newProjectile.transform.position = Gun.transform.position;
    }

    void FindingObject()
    {
        animator = FindObjectOfType<Animator>();

        projectileHolder = GameObject.Find("Projectiles");
        if (!projectileHolder)
        {
            projectileHolder = new GameObject("Projectiles");
        }
    }

    void EnemyDetector()
    {
        if (IsEnemyAhead())
        {
            animator.SetBool("IsAttacking", true);
            //print("Start Attacking");
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            //print("Stop Attacking");
        }
    }

    void DetectEnemyInLane()
    {
        Attacker_Spawner[] spawnerArray = GameObject.FindObjectsOfType<Attacker_Spawner>();
        foreach(Attacker_Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.x == transform.position.x /*& spawner.transform.position.y < 8*/)
            {
                spawnerInLane = spawner;
                return;
            }
        }
        Debug.LogError(name + "Can't find any spawner in lane");
    }

    bool IsEnemyAhead()
    {
        //Exit if there is no attacker in lane
        //print("Number of Children = " + spawnerInLane.transform.childCount);
        if (spawnerInLane.transform.childCount <= 0)
        {
            //if you want to log something do it ,before return statement
            return false;
        }
        
        foreach(Transform attacker in spawnerInLane.transform)
        {
            if(attacker.transform.position.y > transform.position.y)
            {
                return true;
            }
        }

        //Attacker in lane, but behind defender
        return false;
    }

}
