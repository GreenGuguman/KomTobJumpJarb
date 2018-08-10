using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;
    public Animator animator;
    public bool isAdditiveScene;

    private void Start()
    {
        //Transition_Panel = GameObject.Find("Transition_Panel");

        if (autoLoadNextLevelAfter == 0)
        {
            //Debug.Log("value = 0, Auto Load Level Disabled");
        }
        else
        {
            Invoke("FadeToLevel", autoLoadNextLevelAfter);
            Invoke("LoadNextLevel", (autoLoadNextLevelAfter + 2));
        }
        
    }

    public void LoadLevel(string Name) //we need to know which level we are
    {
        //Debug.Log("Level " + Name + " Requested");
        if (isAdditiveScene)
        {
            animator.SetTrigger("Slide_BT");
            SceneManager.LoadScene(Name, LoadSceneMode.Additive);
            //Debug.Log("Single Mode");
        }
        else
        {
            SceneManager.LoadScene(Name, LoadSceneMode.Single);
            //Debug.Log("Additive Mode");
        }

    }

    public void QuitRequest() //hey! just quit no need to know which level
    {
        //Debug.Log("Bye Bye!");
        Application.Quit();
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1), LoadSceneMode.Single);
    }


}
