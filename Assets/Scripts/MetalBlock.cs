using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBlock : MonoBehaviour
{
    AllMaterial cost = new AllMaterial(0, 0, 6, 0);

    public AllMaterial GetCost()
    {
        return cost;
    }
}
