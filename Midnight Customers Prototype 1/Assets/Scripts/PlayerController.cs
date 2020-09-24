using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector2 movement;
    public Rigidbody2D body;
    public float moveSpeed;
    public GameObject currentInteraction;  //object player is currently interacting with

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
            if(currentInteraction != null)
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentInteraction = null;
    }
}
