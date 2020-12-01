using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    bool timerRunning;
    float timeRemaining;
    public GameObject customer;
    void Start()
    {
        timerRunning = true;
        timeRemaining = 20;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerRunning)
        {

            timeRemaining -= Time.fixedDeltaTime; ;
            
            if(timeRemaining <= 0)
            {
                timerRunning = false;
                customer.SetActive(true);
            }

            
        }
    }
}
