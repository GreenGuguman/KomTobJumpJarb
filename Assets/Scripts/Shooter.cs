using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, Gun;
    private GameObject targetObject;

    // Use this for initialization
    void Start () {
        FindingObject();
	}

    private void Fire()
    {
        GameObject newProjectile =  Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = targetObject.transform;
        newProjectile.transform.position = Gun.transform.position;
    }

    void FindingObject()
    {
        targetObject = GameObject.Find("Projectiles");

        if (!targetObject)
        {
            targetObject = new GameObject("Projectiles");
        }
    }

    void CheckForNecessaryObject()
    {
        //ourObject = FindMyObjectInScene();
        //if(ourObject) == null){
            //outObject = SpawnOurObject();
        //}
    }

}
