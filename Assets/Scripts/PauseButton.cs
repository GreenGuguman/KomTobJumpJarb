using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    public static bool gameIsPause;

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
        PauseEvent();
    }

    void PauseEvent()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        gameIsPause = false;
        targetMenu.SetActive(false);
    }

    public void Pause()
    {
        targetMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPause = true;
    }

    //private void OnMouseDown()
    //{
        //targetMenu.SetActive(true);
        //targetMenu.GetComponent<Animator>().SetTrigger("PopUp");
    //}
}
