using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnCookies : MonoBehaviour
{
    //================ UI
    public TextMeshProUGUI cookiesCounter;      //Connect to the Text that keeps track of how many cookies are spawned
    public TextMeshProUGUI cookiesPerSecond;    //Connect to the Text that keeps track of how many cookies spawn per second
    public TextMeshProUGUI buttonText;          //Connect to Auto Button and show's how much it cost to upgrade 
    public Button autoButton;                   //Button used to turn on and off if there is enough in the collector 
    
    //================ Spawning
    public GameObject cookie;                   //The Cookie PreFab 
    public GameObject cookieCollector;          //Where the cookies are spawned into
    public Transform point_1;                   //Point one where the cookie can be spawned 
    public Transform point_2;                   //Point two where the cookie can be spawned 

    //================ Counters 
    private int autoPrice = 10;                 //Keeps track of how much it cost to upgrade 
    private int cookieCounter = 0;              //Keeps track of how many cookies are currently spawned 
    private int autoCookie = 0;                 //Keeps track of how many cookies spawn per second 

    //================= Timer
    private float TIMER = 10f;                  //The timer resets
    private float timeLeft = 10f;               //Current timer 


    //==================================================================
    //Base Functions 
    //==================================================================

    //Pre sets texts on the GUI 
    void Start()
    {
        cookiesCounter.text = "0 Cookies";
        cookiesPerSecond.text = "0 Cookies / second";
        buttonText.text = "Auto Cost - " + autoPrice;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if there is enough cookies spawned to allow the player to upgrade 
        autoButton.interactable = cookieCollector.transform.childCount < autoPrice ? false : true;

        //Counts down till the cookies are spawned 
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            //Spawns i cookies based on what the autoCookie Counter at 
            for (int i = 0; i < autoCookie; i++)
            {
                SpawnCookie();
            }
            //Reset the timer 
            timeLeft = TIMER;
        }
    }

    //==================================================================
    //Button Functions 
    //==================================================================

    //Spawns a single cookie 
    public void SpawnCookie()
    {
        //Generates a postion for the cookie between the two points 
        var pos = new Vector3(Random.Range(point_1.position.x, point_2.position.x), Random.Range(point_1.position.y, point_2.position.y), 0);
        //Creates the cookie 
        var spawn = Instantiate(cookie, pos, Quaternion.identity);
        //Connects to Cookie Collector 
        spawn.transform.SetParent(cookieCollector.transform);
        //Updates the cookie counter 
        cookieCounter++;
        //Updates the GUI text 
        cookiesCounter.text = cookieCounter + " Cookies";
    }
    
    //Upgrades auto cookie geneartion 
    public void AutoCookie()
    {
        //Set the counter 
        int counter = autoPrice;
        //Goes through all of the cookies in the list and remove counters worth 
        foreach(Transform child in cookieCollector.transform)
        {
            if(counter == 0) { break; }
            Destroy(child.gameObject);
            counter--;
          
        }

        //Removes the cost amount from the counter 
        cookieCounter -= autoPrice;
        //Updates cookie counter text 
        cookiesCounter.text = cookieCounter + " Cookies";
        //Incrases how much next upgrade costs 
        autoPrice += 10;
        //Updates the text on button
        buttonText.text = "Auto Cost - " + autoPrice;
        //Update how many cookies will spawn
        autoCookie++;
        //Updates the auto text 
        cookiesPerSecond.text = autoCookie + " Cookies / second";
    }
}
