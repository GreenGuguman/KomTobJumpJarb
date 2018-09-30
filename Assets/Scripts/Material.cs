using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour {

    public float SpwanEverySecond = 60;
    public int willGiveWood, willGiveBrick, willGiveMetal, willGiveCrystal;

    private Inventories inventories;

    //AllMaterial material = new AllMaterial(); //Do i need it?

    // Start is called before the first frame update
    void Start()
    {
        inventories = FindObjectOfType<Inventories>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        //Debug.Log("You clicked me");
        GiveMaterial();
        Destroy(gameObject);
    }

    public void GiveMaterial()
    {
        inventories.addinventory(willGiveWood, willGiveBrick, willGiveMetal, willGiveCrystal);
    }
}
