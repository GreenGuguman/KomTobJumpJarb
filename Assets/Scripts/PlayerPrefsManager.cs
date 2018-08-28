using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    //const = static
    const string MASTER_VOLUME_KEY = "master_vlume";
    const string DIFFICULTY_KEY = "difficulty";
    const string Level_KEY = "level_unlocked_";
    //we need to add level name or number ex. level_unlocked_02

    //what is static //void = function doesn't return value
    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }

        else{
            Debug.Log("R.I.P my ears!!!");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    //Hey! get before set


    // time for level unlock
    public static void SetUnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)//array start from 0
        {
            PlayerPrefs.SetInt(Level_KEY + level.ToString(), 1);//we can't use bool so 1 = true, 0 = flase;
        }
        else
        {
            Debug.LogError("Hey! don't try to load level that doesn't exist");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(Level_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Seriouly! trying to unlock level that doesn't exist?");
            return false;
        }
    }
    
    //Time for difficulty!
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <=3f)//array start from 0
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);//we can't use bool, so 1 = true & 0 = flase;
        }
        else
        {
            Debug.LogError("Seriouly! choosing Difficulty that doesn't exist?");
        }
    }


    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
