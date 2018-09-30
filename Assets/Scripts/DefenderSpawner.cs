using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera targetCamera;

    //private GameObject selectedDefender;
    private GameObject parentObject;
    //private Defenders_TypeB[] defenders_TypeB_Array;

    //private AmountOfMaterial amountOfMaterial;
    private Inventories inventories;

    private void Start()
    {
        FindingObject();
    }

    private void Update()
    {
        //defenders_TypeB_Array = FindObjectsOfType<Defenders_TypeB>();
    }

    void FindingObject()
    {

        //selectedDefender = Button.selectedDefender;
        inventories = FindObjectOfType<Inventories>();

        //amountOfMaterial = FindObjectOfType<AmountOfMaterial>();
        parentObject = GameObject.Find("Defender_TypeA");
        //Strign is dangerous, it won't update if you rename it

        if (!parentObject)
        {
            parentObject = new GameObject("Defender_TypeA");
        }
    }

    private void OnMouseUp()
    {
        //print(Input.mousePosition);
        //print(CalculateWorldPointOfMouseClick());
        //print(SnapToGrid(CalculateWorldPointOfMouseClick()));

        Vector2 rawPosition = CalculateWorldPointOfMouseClick();
        Vector2 roundedPosition = SnapToGrid(rawPosition);
        GameObject selectedDefender = Button.selectedDefender;

        if (!selectedDefender)
        {
            print("Noting Selected");
        }
        else
        {
            //int defenderACost = selectedDefender.GetComponent<Defender_TypeA>().material1Cost;

            //if this script is attached to the child object instead
            //int cost1 = selectedDefender.GetComponentInChildren<AllRequiredMaterial>().neededWood;
            //int cost2 = selectedDefender.GetComponentInChildren<AllRequiredMaterial>().neededBrick;
            //int cost3 = selectedDefender.GetComponentInChildren<AllRequiredMaterial>().neededMetal;
            //int cost4 = selectedDefender.GetComponentInChildren<AllRequiredMaterial>().neededCrystal;

            int cost1 = (selectedDefender.GetComponent<AllRequiredMaterial>().neededWood);
            int cost2 = (selectedDefender.GetComponent<AllRequiredMaterial>().neededBrick);
            int cost3 = (selectedDefender.GetComponent<AllRequiredMaterial>().neededMetal);
            int cost4 = (selectedDefender.GetComponent<AllRequiredMaterial>().neededCrystal);

            //Debug.Log(inventories.test);

            
            if (inventories.UseMaterial(cost1,cost2,cost3,cost4) == Inventories.Status.SUCCESS)
            {
                SpawnDefender(roundedPosition, selectedDefender);
            }
            else
            {
                Debug.Log("Nope! not enough material");
            }
            
        }

    }

    private void SpawnDefender(Vector2 roundedPosition, GameObject targetDefender)
    {
        Quaternion noRotation = Quaternion.identity;

        if (targetDefender == null)
        {
            Debug.Log("Nothing Selected");
        }
        else
        {
            //Debug.Log("current position is "+roundedPosition);

            if (roundedPosition.x <= 0 | roundedPosition.x >= 6)
            {
                print("Invalid X Postion");
            }
            else if (roundedPosition.y <= 0 | roundedPosition.y >= 10) // i don't think if i need this
            {
                print("Invalid Y Postion");
            }
            else
            {
                GameObject newDefender = Instantiate(targetDefender, roundedPosition, noRotation) as GameObject;
                newDefender.transform.parent = parentObject.transform;
            }
        }
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float MouseX = Input.mousePosition.x;
        float MouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(MouseX, MouseY, distanceFromCamera);
        Vector2 worldPosition = targetCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPosition;

    }

}
