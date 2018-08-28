using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider musicVolume_Slider, difficulty_Slider;
    public Text difficultyText;
    public LevelManager levelManager;
    public float defaultVolume, defaultDifficulty;
    //public GameObject backupMusicManger; //can't use for now

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        GetPreference();
    }
	
	// Update is called once per frame
	void Update () {
        SetPreference();
        DifficultyChange();
    }

    public void SaveAndExit(/*string LevelToLoad*/)
    {
        UpdatePreference();
        //Debug.Log(PlayerPrefsManager.GetMasterVolume());
        //we're going to save the options change here, don't know when
        //levelManager.LoadLevel(LevelToLoad); //
    }

    private void DifficultyChange()
    {
        int difficultyLevel = Mathf.RoundToInt(difficulty_Slider.value);
        switch (difficultyLevel)
        {
            case 1:
                difficultyText.text="Easy";
                break;
            case 2:
                difficultyText.text = "Medium";
                break;
            case 3:
                difficultyText.text = "Hard";
                break;
        }
    }

    public void SetDefaults()
    {
        musicVolume_Slider.value = defaultVolume;
        difficulty_Slider.value = defaultDifficulty;
    }

    private void GetPreference()
    {

        musicVolume_Slider.value = PlayerPrefsManager.GetMasterVolume() * 10;
        //As slider value is 10 time greater than PlayerPrefsManager
        //ex. PlayerPrefsManager value = 0.5 -> slider value = 5
        //Debug.Log("New Volume = " + musicVolume_Slider.value);

        difficulty_Slider.value = PlayerPrefsManager.GetDifficulty();
        //Debug.Log("Difficulty = " + PlayerPrefsManager.GetDifficulty());
    }

    private void SetPreference()
    {
        musicManager.SetVolume(musicVolume_Slider.value / 10);
        //Debug.Log(musicVolume_Slider.value);
        DifficultyChange();
    }

    private void UpdatePreference()
    {
        PlayerPrefsManager.SetMasterVolume(musicVolume_Slider.value / 10);
        //Debug.Log(PlayerPrefsManager.GetMasterVolume());
        PlayerPrefsManager.SetDifficulty(difficulty_Slider.value);
    }

}
