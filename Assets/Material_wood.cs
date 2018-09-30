using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_wood : MonoBehaviour
{
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

    public void GiveMaterial()
    {
        inventories.addinventory(willGiveWood, willGiveBrick, willGiveMetal, willGiveCrystal);
    }

}
