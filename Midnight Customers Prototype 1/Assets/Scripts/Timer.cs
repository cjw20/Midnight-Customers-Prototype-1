using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float checkoutTime = 900; 
    public float timeRemaining;
    bool timerRunning = false;
    int displaySeconds;

    public CheckoutMinigame mgControl;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
        timeRemaining = checkoutTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerRunning)
        {
             
            timeRemaining -= Time.fixedDeltaTime; ;
            displaySeconds = Mathf.FloorToInt(timeRemaining % 30);
            

            if (displaySeconds < 10)
            {
                timerText.text = "0:0" + displaySeconds;
            }
            else
            {
                timerText.text = "0:" + displaySeconds;
            }


            if (displaySeconds == 0)
            {
                timerRunning = false;
                mgControl.outOfTime();
            }
        }
    }
}
    
