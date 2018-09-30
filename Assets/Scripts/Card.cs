using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject shadowOfObject;

    private GameObject parentObject;
    private Inventories inventories;

    //private Vector3 MousePosition; //put on hold for a while

    private void Start()
    {
        parentObject = GameObject.Find("Defender_TypeA");

        if (!parentObject)
        {
            parentObject = new GameObject("Defender_TypeA");
        }

        inventories = FindObjectOfType<Inventories>();
    }

    private void Update()
    {
        //MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //comfliction here
    }

    private void OnMouseUp()
    {
        SpawnWithRequirement();
    }

    private void SpawnWithRequirement()
    {
        GameObject selectedDefender = Button.selectedDefender;
        AllRequiredMaterial itWill = selectedDefender.GetComponent<AllRequiredMaterial>();
        int cost1 = (itWill.neededWood);
        int cost2 = (itWill.neededBrick);
        int cost3 = (itWill.neededMetal);
        int cost4 = (itWill.neededCrystal);

        if (inventories.UseMaterial(cost1, cost2, cost3, cost4) == Inventories.Status.SUCCESS)
        {
            Spawn(selectedDefender);
        }
        else
        {
            Debug.Log("Nope! not enough material");
        }
    }

    private void Spawn(GameObject targetObjectToSpawn)
    {
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float newX = Mathf.RoundToInt(currentMousePosition.x);
        float newY = Mathf.RoundToInt(currentMousePosition.y);
        Vector3 roundedPosition = new Vector2(newX, newY);

        if (roundedPosition.x <= 0 | roundedPosition.x >= 6)
        {
            print("Invalid X Postion");
        }
        else if (roundedPosition.y <= 0 | roundedPosition.y >= 10) // i don't think if i need this. oh! now i did
        {
            print("Invalid Y Postion");
        }
        else
        {
            GameObject newDefender = Instantiate(targetObjectToSpawn, roundedPosition, Quaternion.identity) as GameObject;
            newDefender.transform.parent = parentObject.transform;
        }
    }
}
