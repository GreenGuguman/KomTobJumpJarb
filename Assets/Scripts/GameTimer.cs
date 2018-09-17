using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSecond = 10;

    private Slider timeSlider; //make sure it between 0 & 1 always
    private bool isTheEndOfLevel = false;
    private AudioSource audioSource;
    private LevelManager levelManager;
    private GameObject winLabel;

    private void Start()
    {
        CheckingForNeededOnject();
    }

    private void Update()
    {
        Slider();
    }

    private void Slider()
    {
        timeSlider.value = 1 - (Time.timeSinceLevelLoad / levelSecond);
        bool timeIsUp = (Time.timeSinceLevelLoad >= levelSecond);
        if (timeIsUp && !isTheEndOfLevel)
        {
            ObjectsToDestroy();
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadWinScreen", audioSource.clip.length);
            isTheEndOfLevel = true;
        }
    }

    void LoadWinScreen()
    {
        levelManager.LoadLevel("Level_Win");
    }

    void CheckingForNeededOnject()
    {
        timeSlider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();

        winLabel = GameObject.Find("WinningText");
        winLabel.SetActive (false);
        if (!winLabel)
        {
            Debug.LogWarning("please create a text obj name it WinningText :)");
        }

    }

    void ObjectsToDestroy()
    {
        GameObject[] gameObjectsArray;
        gameObjectsArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");

        foreach (GameObject taggedObject in gameObjectsArray)
        {
            if (taggedObject)
            {
                Destroy(taggedObject);
            }
            else
            {
                return;
            }
        }
    }
}
