using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Data : MonoBehaviour
{
    //Variables 
    private static Data _instance; //Is the instance of the object that will show up in each scene 
    private int counter = 0;
    public TextMeshProUGUI textMeshGUI;

    //==================================================================================================================
    // Base Functions 
    //==================================================================================================================

    //Creates the object, if one already has been created in another scene destroy this one and the make a new one 
    private void Start()
    {
        //Checks if there already exits a copy of this, if does destroy it and let the new one be created 
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        textMeshGUI = GameObject.Find("Overlay").transform.Find("Score Text").GetComponent<TextMeshProUGUI>();
    }

    //==================================================================================================================
    // Data Update Methods 
    //==================================================================================================================

    //If player collected a fruit this will update the value to true
    public void SetCounter(int c)
    {
        counter = c;
    }

    //Returns the list of collected fruits, used in start of each level and check in the end scene 
    public int GetCounter()
    {
        return counter;
    }
}
