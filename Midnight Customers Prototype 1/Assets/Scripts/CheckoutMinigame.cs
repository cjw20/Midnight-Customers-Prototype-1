using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutMinigame : MonoBehaviour
{
    public GameObject[] itemSpawns; //where check out items will appear\
    public GameObject checkoutItem; //item that will be checked out. Can add variation later 

    public GameObject customer;
    CustomerInfo customerInfo;

    int itemNumber; //number of items being checked out
    // Start is called before the first frame update
    void Start()
    {
        customerInfo = customer.GetComponent<CustomerInfo>();

        foreach(GameObject itemspawn in itemSpawns)
        {
            Instantiate(checkoutItem, itemspawn.transform);
            itemNumber++;
        }
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
            Destroy(this.gameObject); //ends game when all items have been bagged
        }
    }
}
