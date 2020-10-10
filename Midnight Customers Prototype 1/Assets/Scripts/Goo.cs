﻿using System.Collections;
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

    bool hitBoundary = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeLeft = directionTime;

        mgControl = GameObject.Find("Mop Goo MiniGame(Clone)").GetComponent<MopGooGame>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime; 
        if(timeLeft < 0 && !hitBoundary)
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
            mgControl.UpdateGooCount(-1); //tells game that there is one less slime present
            Destroy(this.gameObject); //destroys slime after a certain amount of time being cleaned
            
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

            mgControl.UpdateGooCount(-1); //tells game that there is one less slime present
            Destroy(this.gameObject); //destroys slime after a certain amount of time being cleaned

        }
        if (collision.tag == "Boundary")
        {
            rb.velocity = -rb.velocity;  //reverses velocity so that goo doesn't leave the minigame window
            movement = -movement;
            rb.AddForce(movement * moveSpeed * 3);


            StartCoroutine("HitBoundary");
        }
       
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MiniGamePlayer")
        {
            isBeingCleaned = false;
        }
    }

    IEnumerator HitBoundary()
    {
        if (hitBoundary)
            yield break;  //ends coroutine if already started

        //keeps goo turning right back around after hitting edge of minigame screen
        hitBoundary = true;

        yield return new WaitForSeconds(2f);

        hitBoundary = false;

        yield break;
    }
}
