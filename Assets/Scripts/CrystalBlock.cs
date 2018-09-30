using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBlock : MonoBehaviour
{
    AllMaterial cost = new AllMaterial(0, 0, 0, 5);

    public AllMaterial GetCost()
    {
        return cost;
    }
}
