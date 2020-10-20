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

    public Transform Exit; //exit to store
    bool wantsToLeave = false;

    public int causedStress = -25; //stress caused by interacting with customer



    void Start()
    {
        agent = GetComponent<NavMeshAgent2D>();
        waypoints = GameObject.FindGameObjectsWithTag("Destination");
        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
            return;

        

        if (!agent.pathPending && agent.remainingDistance < minDistance)
        {
            if (agent.destination == new Vector2 (Exit.position.x, Exit.position.y))
            {
                Destroy(this.gameObject);
                return;
            }
            else
            {
                StartCoroutine("wait");
            }
        }
            
            
    }
    void GoToNextPoint()
    {
        if(wantsToLeave == true)
        {
            agent.destination = Exit.position;
            return;
        }

        agent.destination = waypoints[destination].transform.position;

        destination = (destination + 1) % waypoints.Length;

        
    }

    IEnumerator wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(timeToWait);
        isWaiting = false;
        GoToNextPoint();
        yield break;
    }
}
