using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector2 movement;
    public Rigidbody2D body;
    public float moveSpeed;
    public GameObject currentInteraction;  //object player is currently interacting with
    InteractableItem itemScript; //script for item player is interacting with

    bool nearCustomer;
    public GameObject closestCustomer; //for use if multiple customers are in range of player interaction

    InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
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
                if (itemScript.canHold)
                {
                    inventoryManager.addItem(itemScript.itemName, itemScript.amount); 
                    Destroy(currentInteraction);  //Adds item to inventory and removes from overworld
                }
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
            itemScript = currentInteraction.GetComponent<InteractableItem>();
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
            itemScript = null;
        }
        if (other.tag == "Customer")
        {
            nearCustomer = false;
            closestCustomer = null;  //resets variable so that player can no longer interact after leaving trigger area

        }
    }
}
