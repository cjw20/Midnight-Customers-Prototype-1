using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutItem : MonoBehaviour
{
     
    bool isHeld = false;
    float startPosX;
    float startPosY;

    CheckoutMinigame mgControl; 

    public float price; //price of item to be displayed on register

    public bool isScanned = false; //whether or not the item has been scanned and is ready to be bagged
    // Start is called before the first frame update
    void Start()
    {
        mgControl = GameObject.Find("Check Out Minigame(Clone)").GetComponent<CheckoutMinigame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, -1);
        }
    }
    private void OnMouseDown()
    {
        //currently left or right mouse, can specify later if want
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        startPosX = mousePos.x - this.transform.localPosition.x;
        startPosY = mousePos.y - this.transform.localPosition.y; //keeps mop from jumping around when picking it up

        isHeld = true;
    }

    private void OnMouseUp()
    {
        isHeld = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bag")
        {
            if (isScanned)
            {
                mgControl.UpdateItemCount();
                Destroy(this.gameObject);
                //tell game that it is scanned
                //update price
            }
        }
        if(collision.CompareTag("Scanner"))
        {
            if (!isScanned)
            {
                isScanned = true;
                mgControl.UpdatePrice(price);
            }
            
        }
    }
}
