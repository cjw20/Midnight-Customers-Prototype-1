using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goo : MonoBehaviour
{
    bool isBeingCleaned; //if mop is in contact with goo
    float timeCleaned; //how long the mop is in contact with the goo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBeingCleaned == true)
        {
            timeCleaned += Time.deltaTime;  //time.deltatime = 0.0166 seconds 
            //do more precise math later
        }

        if(isBeingCleaned == false)
        {
            timeCleaned = 0; //resets time to 0 when goo escapes mop. Maybe dont reset?
        }

        if(timeCleaned > 1.5f)
        {
            Destroy(this.gameObject); //destroys slime after a certain amount of time being cleaned
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MiniGamePlayer")
        {
            isBeingCleaned = true;
        }
       
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MiniGamePlayer")
        {
            isBeingCleaned = false;
        }
    }
}
