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
    bool hasPrerequisite; //if player has requirement for interaction

    bool nearCustomer;
    public GameObject closestCustomer; //for use if multiple customers are in range of player interaction

    InventoryManager inventoryManager;

    GameControl gameControl;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
        gameControl = GameObject.Find("Game Control").GetComponent<GameControl>();
        SetPosition();
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
                if (itemScript.hasPrerequisite)
                {
                    hasPrerequisite = inventoryManager.itemCheck(itemScript.prerequisite); //true if prerequisite is held false if not

                    if (!hasPrerequisite) //end interaction
                        return; //show no prereq message here
                }
                if (itemScript.canHold)
                {
                    inventoryManager.addItem(itemScript.itemName, itemScript.amount); 
                    Destroy(currentInteraction);  //Adds item to inventory and removes from overworld
                    //maybe only pickup 1 at a time, and only destroy if 0 left?
                }

                else if (itemScript.isMiniGameTrigger)
                {
                    itemScript.StartInteraction();
                    //trigger minigame
                }

                //if neither???

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

    void SetPosition()
    {
        if(gameControl.playerPos == null)
        {
            return; //if a position isn't set, stay in default position
        }

        this.gameObject.transform.position = gameControl.playerPos;
    }
}
