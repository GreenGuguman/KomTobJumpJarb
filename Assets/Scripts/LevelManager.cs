using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    public Animator animator;

    private void Start()
    {


        if (autoLoadNextLevelAfter <= 0)
        {
            //Debug.Log("value = 0 or less than 1, Auto Load Level Disabled");
        }
        else
        {
            FadeToNextLevel();
        }
        
    }

    public void FadeAnimation()
    {
        animator.SetTrigger("FadeOut");
    }

    public void FadeToNextLevel()
    {
        Invoke("FadeAnimation", (autoLoadNextLevelAfter / 2));
        Invoke("LoadNextLevel", autoLoadNextLevelAfter);
    }

    public void LoadLevel(string Name) //we need to know which level we are
    {
        //Debug.Log("Level " + Name + " Requested");
        SceneManager.LoadScene(Name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest() //hey! just quit no need to know which level
    {
        //Debug.Log("Bye Bye!");
        Application.Quit();
    }
}
