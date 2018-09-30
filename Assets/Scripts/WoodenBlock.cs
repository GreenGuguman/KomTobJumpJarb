using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBlock : MonoBehaviour
{
    AllMaterial cost = new AllMaterial(8, 0, 0, 0);

    public AllMaterial GetCost()
    {
        return cost;
    }
}
