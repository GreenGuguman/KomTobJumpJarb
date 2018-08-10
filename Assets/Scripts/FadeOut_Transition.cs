using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut_Transition : MonoBehaviour {

    public float TransitionTime;

    private Image FadeIn_Panel;
    private Color CurrentColor = Color.black;

    // Use this for initialization
    void Start()
    {
        FadeIn_Panel = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < TransitionTime)
        {
            float AlphaChange = Time.deltaTime / TransitionTime;
            CurrentColor.a += AlphaChange;
            FadeIn_Panel.color = CurrentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
