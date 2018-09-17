using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker_Spawner : MonoBehaviour {

    public GameObject[] attackerArray;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SpawnAttacker();
	}

    void SpawnAttacker()
    {
        foreach(GameObject thisAttacker in attackerArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    //Spawn method here
    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        // why we spawn to the spawner not like defender?
        //bcuz we want the projectile to remain after defender is destroy

        myAttacker.transform.position = transform.position;
        //make sure you didn't spawn them in the shreder
    }

    bool isTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker_TypeA attackerA = attackerGameObject.GetComponentInChildren<Attacker_TypeA>();

        float spawnDelay = attackerA.spawnEverySecond;
        float spawnPersecond = 1 / spawnDelay;

        if (Time.deltaTime > spawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate and that's bad");
        }

        float threshold = spawnPersecond * Time.deltaTime / 5; //we have 5 lanes
        return (Random.value < threshold);
        //Always make it clear to read
    }
}
