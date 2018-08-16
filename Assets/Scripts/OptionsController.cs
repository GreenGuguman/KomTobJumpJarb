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

    #region my crazy code
    private bool RequiredObjectCheck()
    {
        if(musicManager = FindObjectOfType<MusicManager>())
        {
            Debug.Log("Music Manager Checked");
            return true;
        }
        else
        {
            //backupMusicManger.SetActive(true);
            Debug.Log("Phew! we have backup");
            return false;
        }

    }

    void VolumeChange()
    {
        if (musicManager == null)
        {
            //Debug.Log("oh no");
            //musicManager.SetVolume(musicVolume_Slider.value);
            Application.Quit();
        }
        else
        {
            musicManager.SetVolume(musicVolume_Slider.value);    
        }
    }
    #endregion

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
        musicVolume_Slider.value = PlayerPrefsManager.GetMasterVolume() / 10;
        difficulty_Slider.value = PlayerPrefsManager.GetDifficulty();
    }

    private void SetPreference()
    {
        musicManager.SetVolume(musicVolume_Slider.value / 10);
        DifficultyChange();
    }

    private void UpdatePreference()
    {
        PlayerPrefsManager.SetMasterVolume(musicVolume_Slider.value / 10);
        PlayerPrefsManager.SetDifficulty(difficulty_Slider.value);
    }

}
