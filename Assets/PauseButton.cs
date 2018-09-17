using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    public GameObject targetMenu;
    //private LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        //levelManager = FindObjectOfType<LevelManager>();
    }
	// Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        targetMenu.SetActive(true);
        targetMenu.GetComponent<Animator>().SetTrigger("SlideDown");
    }
}
