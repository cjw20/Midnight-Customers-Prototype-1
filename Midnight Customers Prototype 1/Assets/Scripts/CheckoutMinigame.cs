using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckoutMinigame : MonoBehaviour
{
    enum CheckoutState {Greeting, Chat, Goodbye, Finished};
    CheckoutState currentState;

    public GameObject[] itemSpawns; //where check out items will appear\
    public GameObject checkoutItem; //item that will be checked out. Can add variation later 
    GameObject[] boughtItems;

    public SpriteRenderer portraitLocation;

    public GameObject customer;
    CustomerInfo customerInfo;

    bool itemsBagged = false; //set to true once all items have been bagged
    bool dialogueFinished = false; //true when conversation is finished

    int itemNumber; //number of items being checked out
    // Start is called before the first frame update


    public GameObject dialogueBox;
    //public Text nameText; //name to display for customer
    public TextMesh message; //what customer is saying
    public GameObject[] responseButtons;
    public TextMesh[] responseText;

    CheckoutTrigger checkoutTrigger;

    void Start()
    {
        currentState = CheckoutState.Greeting; 

        checkoutTrigger = GameObject.Find("Checkout Counter").GetComponent<CheckoutTrigger>();
        customer = checkoutTrigger.customer; //loads in info from customer standing in front of counter

        customerInfo = customer.GetComponent<CustomerInfo>();

        //nameText.text = customerInfo.name;
        message.text = customerInfo.greetingMessage;

        int i = 0; // variable for counting in loops 
        foreach(string response in customerInfo.greetingResponses)
        {
            responseText[i].text = response;
            i++;
        }

        boughtItems = customerInfo.boughtItems;
        i = 0;
        foreach(GameObject item in boughtItems)
        {
            Instantiate(item, itemSpawns[i].transform);
            itemNumber++;
            i++;
        }

        portraitLocation.sprite = customerInfo.portrait;

        //put some of these in separate functions later^
    }

   

    public void UpdatePrice(float cost)
    {
        //update price when object gets scanned
    }

    public void UpdateItemCount()
    {
        itemNumber--;
        if(itemNumber < 1)
        {
            itemsBagged = true;
            FinishCheckout();
        }
    }

    void FinishCheckout()
    {
        if(itemsBagged && dialogueFinished)
        {
           
            checkoutTrigger.EndCheckout();
        }
    }


    public void NextDialogue()
    {
        switch (currentState)
        {
            case CheckoutState.Greeting:
                {
                    message.text = customerInfo.progressMessage;
                    int i = 0; // variable for counting in loops 
                    foreach (string response in customerInfo.progressResponses)
                    {
                        responseText[i].text = response;
                        i++;
                    }
                    currentState = CheckoutState.Chat;
                    break;
                }
            case CheckoutState.Chat:
                {
                    message.text = customerInfo.goodbyeMessage;
                    int i = 0; // variable for counting in loops 
                    foreach (string response in customerInfo.goodbyeResponses)
                    {
                        responseText[i].text = response;
                        i++;
                    }
                    currentState = CheckoutState.Goodbye;
                    break;
                }
            case CheckoutState.Goodbye:
                {
                    dialogueBox.SetActive(false);
                    foreach(GameObject button in responseButtons)
                    {
                        button.SetActive(false);
                    }
                    currentState = CheckoutState.Finished;
                    dialogueFinished = true;
                    FinishCheckout();
                    break;
                }
            default:
                {
                    Debug.Log("Uh oh");
                    break;
                }
                
        }

        //clean up later 
       
    }
}
