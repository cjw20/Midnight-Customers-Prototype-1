using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutTrigger : MonoBehaviour
{
    public GameObject customer;
    public GameObject checkoutGame;
    public bool customerNear; //true if customer is ready for checkout
    GameObject thisCheckout;

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
        thisCheckout = Instantiate(checkoutGame);
    }

    public void EndCheckout()
    {
        Destroy(thisCheckout);
    }
}
