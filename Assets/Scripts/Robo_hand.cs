using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo_hand : MonoBehaviour {

    AllMaterial cost = new AllMaterial(3, 0, 4, 0);

    public AllMaterial GetCost()
    {
        return cost;
    }
}
