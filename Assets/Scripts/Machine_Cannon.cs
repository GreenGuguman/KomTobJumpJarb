using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Cannon : MonoBehaviour {

    AllMaterial cost = new AllMaterial(0, 3, 10, 0);

    public AllMaterial GetCost()
    {
        return cost;
    }
}

