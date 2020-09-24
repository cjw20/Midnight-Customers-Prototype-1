using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector2 movement;
    public Rigidbody2D body;
    public float moveSpeed;
    public GameObject currentInteraction;  //object player is currently interacting with

    bool nearCustomer;
    public GameObject closestCustomer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); //movement using wasd or arrow keys


        if(Input.GetKeyDown(KeyCode.E))
        {
            if (nearCustomer)
            {

            }
            
            else if(currentInteraction != null)   //prioritizes customers over items, may need to change how this works later
            {
                //interact
            }
           
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Interactable")
        {
            currentInteraction = other.gameObject;
        }

        if(other.tag == "Customer")
        {
            nearCustomer = true;
            closestCustomer = other.gameObject;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Interactable")
        {
            currentInteraction = null;
        }
        if (other.tag == "Customer")
        {
            nearCustomer = false;
            closestCustomer = null;

        }
    }
}
