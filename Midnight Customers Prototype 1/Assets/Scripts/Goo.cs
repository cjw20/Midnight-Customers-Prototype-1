using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goo : MonoBehaviour
{
    bool isBeingCleaned; //if mop is in contact with goo
    float timeCleaned; //how long the mop is in contact with the goo
    public float cleanTimeRequired = 1.5f; //time needed in order for goo to disapear
    public float moveSpeed = 3f;
    Vector2 movement;
    public float directionTime = 1f; //time before goo changes directions
    float timeLeft; //used to see how much time has passed

    public MopGooGame mgControl; 

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeLeft = directionTime;

        mgControl = GameObject.Find("Mop Goo MiniGame").GetComponent<MopGooGame>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime; 
        if(timeLeft < 0)
        {
            timeLeft += directionTime;
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)); //chooses a random direction for slime to move
        }

        if(isBeingCleaned == true)
        {
            timeCleaned += Time.deltaTime;  //time.deltatime = 0.0166 seconds 
            //do more precise math later
        }

        if(isBeingCleaned == false)
        {
            timeCleaned = 0; //resets time to 0 when goo escapes mop. Maybe dont reset?
        }

        if(timeCleaned > cleanTimeRequired)
        {
            Destroy(this.gameObject); //destroys slime after a certain amount of time being cleaned
            mgControl.UpdateGooCount(-1); //tells game that there is one less slime present
        }
       
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * moveSpeed);
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
