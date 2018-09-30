using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateriaSpawner : MonoBehaviour
{
    public GameObject[] RandomMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpawnMaterial();
    }

    private void SpawnMaterial()
    {
        foreach(GameObject thisMaterial in RandomMaterial)
        {
            if (isTimeToSpawn(thisMaterial))
            {
                Spawn(thisMaterial);
            }
        }
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject myMaterial = Instantiate(myGameObject) as GameObject;
        myMaterial.transform.parent = transform;
        myMaterial.transform.position = transform.position;
    }

    bool isTimeToSpawn(GameObject spawnerGameObject)
    {
        Material material = spawnerGameObject.GetComponent<Material>();
        float spawnDelay = material.SpwanEverySecond;
        float spawnPersecond = 1 / spawnDelay;

        if (Time.deltaTime > spawnDelay)
        {
            Debug.Log("Spawn rate like this is not good");
        }

        float threshold = spawnPersecond * Time.deltaTime / 4; //we have 4 objects
        return (UnityEngine.Random.value < threshold);
    }

}
