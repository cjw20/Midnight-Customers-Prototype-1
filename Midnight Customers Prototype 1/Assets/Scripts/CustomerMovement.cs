using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    
    public Rigidbody2D body;
    public float moveSpeed;
    NavMeshAgent2D agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
