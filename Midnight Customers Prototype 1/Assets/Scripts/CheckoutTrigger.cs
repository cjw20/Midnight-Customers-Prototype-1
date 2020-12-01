using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutTrigger : MonoBehaviour
{
    public GameObject customer;
    public GameObject checkoutGame;
    public bool customerNear; //true if customer is ready for checkout
    GameObject thisCheckout;
    public GameObject sanityMeter;
    public GameObject nextCustomer; //next customer to load into scene. can make more sophisticated method later if necessary for more customers
    bool noMoreCustomers = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Customer"))
        {
            customer = collision.gameObject;
            customerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Customer"))
        {
            customer = null;
            customerNear = false;
        }
    }

    public void StartCheckout()
    {
        //sanityMeter.SetActive(false);
        thisCheckout = Instantiate(checkoutGame);
    }

    public void EndCheckout()
    {
        if (noMoreCustomers == false)
        {
            nextCustomer.SetActive(true);
            noMoreCustomers = true;
        }


        //sanityMeter.SetActive(true);
        
        customer.GetComponent<CustomerMovement>().FinishedCheckout(); //tells customer to leave after checking out
        Destroy(thisCheckout);
    }
}
