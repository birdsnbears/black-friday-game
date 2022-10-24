using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{

    //public Animator transition;

    public float transitionTime = 1f;


    // Update is called once per frame
    /*
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }

    }
    */
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }

    public void ReturnToMainMenu()
    {
        /*Application.LoadLevel("Main Menu") ;*/
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        //transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
    }
}
