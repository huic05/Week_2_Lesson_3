using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI GUI;
    private int counter = 0;
   private DataTwo
    // Start is called before the first frame update
    void Start()
    {
        GUI.text = "Score" + counter;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        GUI.text = "Score" + counter;
    }
}

