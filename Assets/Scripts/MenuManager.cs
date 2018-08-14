using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Animator animator;
    public float animationDelay;
    public GameObject targetObject;

    public string defaultAnimation = "SlideDown";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            LoadMenuWithAnimation(defaultAnimation);
        }
	}

    public void AnimationToLoad(string animationName)
    {
        animator.SetTrigger(animationName);
    } 

    public void LoadMenuWithAnimation(string animationName)
    {
        if (targetObject.activeInHierarchy)
        {
            animator.SetTrigger(animationName);
        }
        else
        {
            targetObject.SetActive(true);
            animator.SetTrigger(animationName);
        }
    }


    public void WaitForAnimation(string animationToLoad)
    {
        animator.SetTrigger(animationToLoad);
        
    }

    public void AutoLoadMenu()
    {
        Invoke("AnimationToLoad", animationDelay);
    }

}
