using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsArray;
    public Vector3 spawnPositionValue;
    private float spawnDelay;
    public float spawnMaxDelay;
    public float spawnMinDelay;
    //private Vector3 spawnPosition;
    public int startDealy;
    public bool stop = true;
    public bool willSpawnInRandomPosition = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelaySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnDelay = Random.Range(spawnMinDelay, spawnMaxDelay);
    }

    IEnumerator DelaySpawner() {
        yield return new WaitForSeconds(startDealy);

        while (!stop)
        {
            //i want to use array lenght as max size :(
            int maxSize = objectsArray.Length;
            //print(maxSize);
            int randomObject = Random.Range(0, maxSize); //trust me it work, if it doesn't blame our boss lolz

            //our attacker will spawn in specific position but our material don't
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnPositionValue.x, spawnPositionValue.x), 0f, 0f);
            GameObject spawnObject = Instantiate(objectsArray[randomObject]) as GameObject;
            spawnObject.transform.parent = transform;

            if (willSpawnInRandomPosition)
            {
                spawnObject.transform.position = transform.position + spawnPosition;
            }
            else
            {
                spawnObject.transform.position = transform.position;
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

}
