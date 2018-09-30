using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventories : MonoBehaviour
{
    public enum Status { SUCCESS, FAILURE };
    public Text txtWood, txtBrick, txtMetal, txtCrystal;

    AllMaterial inventory = new AllMaterial(0,0,0,0);

    public void addinventory(int addWood, int addBrick, int addMetal, int addCrystal)
    {
        inventory.wood += addWood;
        inventory.brick += addBrick;
        inventory.metal += addMetal;
        inventory.crystal += addCrystal;

        UpDateAmount();
    }

    public Status UseMaterial(int availableWood, int availableBrick, int availableMetal, int availableCrystal)
    {
        if (
            inventory.wood      >= availableWood    && 
            inventory.brick     >= availableBrick   && 
            inventory.metal     >= availableMetal   && 
            inventory.crystal   >= availableCrystal
           )
        {
            inventory.wood -= availableWood;
            inventory.brick -= availableBrick;
            inventory.metal -= availableMetal;
            inventory.crystal -= availableCrystal;

            UpDateAmount();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void Start()
    {
        UpDateAmount();
    }

    void UpDateAmount()
    {
        txtWood.text = inventory.wood.ToString();
        txtBrick.text = inventory.brick.ToString();
        txtMetal.text = inventory.metal.ToString();
        txtCrystal.text = inventory.crystal.ToString();
    }

}
