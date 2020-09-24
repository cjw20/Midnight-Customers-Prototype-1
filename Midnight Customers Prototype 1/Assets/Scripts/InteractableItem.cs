using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public string itemName; //name of item that will show up in inventory/ UI
    public bool canHold; //true if item can be picked up and put into player inventory
    public int amount; //amount of the item that the player will pickup 
    public bool isMiniGameTrigger; //if interacting with this will trigger minigame
    public bool hasPrerequisite; //if interaction requires something from the player in order for it to occur properly
    public string noPrereqMessage; //message shown to player if they dont have proper prerequisite fullfilled
    public string prerequisite; //name of requirement for interaction ex. Mop

    
    public GameObject miniGame; //minigame that will be triggered
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartInteraction()
    {
        if (isMiniGameTrigger)
        {
            Instantiate(miniGame);
            
        }
        //trigger item specific interaction
    }
}
