using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    //Holds the name of the next level 
    public string nextLevelName; 

    //Used by the button to load the scene 
   public void LoadScene()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    //Used by a Trigger Collider 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadScene();
        }
    }

}
