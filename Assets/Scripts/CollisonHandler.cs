using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{
    [SerializeField] float delayload = 1f;
    void OnCollisionEnter(Collision other) 
    {
        //Switch Statement are a Conditional like If/Else Statement
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Im Not dead"); 
                break;
            case "Finish":
                NextLevel();
                break;
            case "Fuel":
                Debug.Log("I can still fly"); 
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void NextLevel()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayload);
    }

    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayload);
        
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        // one way to do this.  SceneManager.LoadScene(0);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentSceneIndex);
    }
}
