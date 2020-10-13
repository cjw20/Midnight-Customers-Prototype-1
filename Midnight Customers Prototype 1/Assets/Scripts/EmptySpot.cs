using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpot : MonoBehaviour
{

    public SpriteRenderer spriteRenderer; //shows that spot needs to be filled
    public Sprite itemSprite;

    public bool isStocked = false;
    

    StockingMinigame mgControl;
    void Start()
    {
        mgControl = GameObject.Find("Stocking Minigame(Clone)").GetComponent<StockingMinigame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        if (!isStocked)
        {
            spriteRenderer.sprite = itemSprite;
            this.gameObject.transform.localScale = new Vector3(4f, 4f, 4f);  //increases size of can to better fit shelf. probably wont need this part later
            mgControl.UpdateCount();
        }
        //remove ! and put item on shelf
    }
}
