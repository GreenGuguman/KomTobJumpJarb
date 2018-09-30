using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_CrystalBlock : MonoBehaviour
{
    public Text cost1TXT, cost2TXT;
    private GameObject defenderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        defenderPrefab = GetComponentInParent<Button>().defenderPrefab;
        SetText();
    }

    void SetText()
    {

        cost1TXT.text = defenderPrefab.GetComponentInChildren<AllRequiredMaterial>().neededCrystal.ToString();

        if (cost2TXT)
        {

        }
        else
        {
            //Debug.Log("it's ok");
        }
    }
}
