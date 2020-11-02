using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckoutMinigame : MonoBehaviour
{
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


    public GameObject dialogueWindow;
    public Text nameText; //name to display for customer
    public Text message; //what customer is saying
    public GameObject[] responseButtons;

    void Start()
    {
        customerInfo = customer.GetComponent<CustomerInfo>();
        boughtItems = customerInfo.boughtItems;
        int i = 0;
        foreach(GameObject item in boughtItems)
        {
            Instantiate(item, itemSpawns[i].transform);
            itemNumber++;
            i++;
        }

        portraitLocation.sprite = customerInfo.portrait;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            //display goodbye message
            Destroy(this.gameObject); //end minigame
        }
    }
}
