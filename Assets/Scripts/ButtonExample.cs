using System.Collections;
using System.Collections.Generic;
//You have to be using TMPro to connect
//To the GUI elements 
using TMPro;
using UnityEngine;

public class ButtonExample : MonoBehaviour
{
    //Counts how many times the button has been pressed 
    private int _buttonCounter = 0;
    //Connect to the Text On Screen that will update 
    public TextMeshProUGUI textMesh;
    private Data data;

    public void Start()
    {
        data = GameObject.Find("Data").GetComponent<Data>();
        _buttonCounter = data.GetCounter();
        textMesh.text = "Score: " + _buttonCounter;
    }

    //Increments the button Counter and update the text shown in the
    //Text box 
    public void UpdateText()
    {
        _buttonCounter++;
        data.SetCounter(_buttonCounter);
        textMesh.text = "Score: " + _buttonCounter;
    }
}
