using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMop : MonoBehaviour
{

    public Collider2D mopHead; //part of mop that is used to clean
    float startPosX;
    float startPosY;

    bool isHeld = false; //if the player is currently clicking on and draging mop
    void Start()
    {
       
    }

    void Update()
    {
        if(isHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
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
}
