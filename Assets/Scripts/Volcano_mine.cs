using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano_mine : MonoBehaviour {

    AllMaterial cost = new AllMaterial(0, 4, 0, 5);

    public AllMaterial GetCost()
    {
        return cost;
    }
}
