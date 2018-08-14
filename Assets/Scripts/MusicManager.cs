using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] MusicOnLevelChangeArray;

    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //Debug.Log("Hey im still alive " + name);

        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
		audioSource = GetComponent<AudioSource>();
	}

    void OnEnable()
    {
        //Tell 'OnLevelFinishedLoading' function to start listening for a scene change as soon as
        //this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as
        //this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //Use the buildIndex of the scene to pass the level value to the the array
        AudioClip thisLevelMusic = MusicOnLevelChangeArray[scene.buildIndex];
        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    /*void OnLevelWasLoaded(int level)
    {
        AudioClip MusicOfThisLevel = MusicOnLevelChangeArray[level];
        Debug.Log("And The Music of this level is " + MusicOfThisLevel);

        if (MusicOfThisLevel) //if there is a music attach to it
        {
            audioSource.clip = MusicOfThisLevel;
            audioSource.loop = true;
            audioSource.Play(musicDelayTime);
        }

    }*/

}
