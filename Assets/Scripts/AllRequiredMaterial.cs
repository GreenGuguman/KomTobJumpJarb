using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AllRequiredMaterial : MonoBehaviour
{
    public int neededWood, neededBrick, neededMetal, neededCrystal;
    //AllMaterial needed = new AllMaterial();

    public AllRequiredMaterial(int requiredWood, int requiredBrick, int requiredMetal, int requiredCrystal)
    {
        /*
        neededWood = needed.wood;
        neededBrick = needed.brick;
        neededMetal = needed.metal;
        neededCrystal = needed.crystal;
        */

        this.neededWood = requiredWood;
        this.neededBrick = requiredBrick;
        this.neededMetal = requiredMetal;
        this.neededCrystal = requiredCrystal;

    }

}
