using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Slider stressSlider;

    int currentStress = 100;
    int maxStress = 100;
    int sanity = 0;

    public CheckoutTrigger checkoutTrigger;
    bool nearCheckout = false;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
        gameControl = GameObject.Find("Game Control").GetComponent<GameControl>();
        SetPosition();
        SetStress();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); //movement using wasd or arrow keys


        if(Input.GetKeyDown(KeyCode.E))
        {
            if (nearCheckout && checkoutTrigger.customerNear)
            {
                checkoutTrigger.StartCheckout();
                return;
            }

            if (nearCustomer)
            {
                
                //closestCustomer.GetComponent<DialogueTrigger>().TriggerDialogue();
                //UpdateStress(closestCustomer.GetComponent<DialogueTrigger>().causedStress); //make more efficent later

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
                    UpdateStress(itemScript.causedStress);
                    itemScript.StartInteraction();
                    
                    //trigger minigame
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
        if(other.CompareTag("Interactable"))
        {
            currentInteraction = other.gameObject;
            itemScript = currentInteraction.GetComponent<InteractableItem>();
        }

        if(other.CompareTag("Customer"))
        {
            nearCustomer = true;
            closestCustomer = other.gameObject;
          

        }
        if (other.CompareTag("Counter"))
        {
            nearCheckout = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Interactable"))
        {
            currentInteraction = null;
            itemScript = null;
        }
        if (other.CompareTag("Customer"))
        {
            nearCustomer = false;
            closestCustomer = null;  //resets variable so that player can no longer interact after leaving trigger area

        }
        if (other.CompareTag("Counter"))
        {
            nearCheckout = false;
        }
    }

    void SetPosition()
    {
        if(gameControl.playerPos == new Vector3 (0,0,0))
        {
            return; //if a position isn't set, stay in default position
        }

        this.gameObject.transform.position = gameControl.playerPos;

        //won't need this if we stay in gas station scene
    }

    public void SetStress()
    {
        stressSlider.maxValue = maxStress;
        stressSlider.value = currentStress;

    }

    public void UpdateStress(int stressChange)
    {
        currentStress += stressChange;
        if(currentStress < 0)
        {
            sanity += currentStress; //excess stress is added to sanity
            currentStress = 0;

        }
        stressSlider.value = currentStress;
    }
}
