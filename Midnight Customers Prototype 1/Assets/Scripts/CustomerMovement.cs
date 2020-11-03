using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    
    //public Rigidbody2D body;
    
    NavMeshAgent2D agent;

   // public float speed = 5f;
    public float minDistance = 0.5f;
    public GameObject[] waypoints;
    public int destination = 0;
    public Transform target;
    public float timeToWait = 5f; //time for customer to chill at destination before moving to next one
    bool isWaiting;


    public bool hasCheckedOut = false; //set to true after checkout minigame completed

    // public int causedStress = -25; //stress caused by interacting with customer

    public Transform[] plannedPath; //an array of waypoints that the customer will travel to in course of time in store
    public Transform checkout;

    void Start()
    {
        agent = GetComponent<NavMeshAgent2D>();
        //waypoints = GameObject.FindGameObjectsWithTag("Destination");
        GoToNextPoint(); //goes to first destination in planned path
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
            return;

        

        if (!agent.pathPending && agent.remainingDistance < minDistance)
        {
            
            StartCoroutine("Wait");
            
        }
            
            
    }
    void GoToNextPoint()
    {
        if(destination >= plannedPath.Length)
        {
            Destroy(this.gameObject); //customer leaves store when path is done
            return;
        }

        agent.destination = plannedPath[destination].position;

        destination++;

        isWaiting = false;
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(timeToWait);
        
        GoToNextPoint();
        yield break;
    }
}
