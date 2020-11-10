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

    public int causedStress; //amount of stress caused by interaction
    
    public GameObject miniGame; //minigame that will be triggered
    public GameObject gameControl;
    GameControl gc;
    
  
    public void StartInteraction()
    {
        if (isMiniGameTrigger)
        {

            gameControl = GameObject.Find("Game Control");
            gc = gameControl.GetComponent<GameControl>();

            gc.LoadMiniGame(miniGame);
            Destroy(this.gameObject);

            

            
        }
        //trigger item specific interaction
    }
}
