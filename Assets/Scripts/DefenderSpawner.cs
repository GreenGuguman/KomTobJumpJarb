using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera targetCamera;

    private GameObject parentObject;
    //private Defenders_TypeB[] defenders_TypeB_Array;

    private AmountOfMaterial amountOfMaterial;

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
        amountOfMaterial = FindObjectOfType<AmountOfMaterial>();
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
        GameObject targetDefender = Button.selectedDefender;

        int defenderACost = targetDefender.GetComponent<Defender_TypeA>().materialCost;
        if (amountOfMaterial.UseMaterial(defenderACost) == AmountOfMaterial.Status.SUCCESS)
        {
            SpawnDefender(roundedPosition, targetDefender);
        }
        else
        {
            Debug.Log("Nope! not enough material");
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
