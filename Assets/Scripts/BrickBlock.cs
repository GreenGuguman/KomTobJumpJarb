using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock : MonoBehaviour
{
    AllMaterial cost = new AllMaterial(0, 7, 0, 0);

    public AllMaterial GetCost()
    {
        return cost;
    }
}
