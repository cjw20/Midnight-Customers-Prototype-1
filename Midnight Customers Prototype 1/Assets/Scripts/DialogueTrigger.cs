using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    public TextAsset[] conversations;
    public InkExample inkManager;
    int numberOfInteractions = 0; //how many times the interaction has occured so that the right dialogue is chosen.
    public void TriggerDialogue()
    {
        if(inkManager == null)
        {
            inkManager = GameObject.Find("Dialogue Canvas").GetComponent<InkExample>();
        }
        

        if(numberOfInteractions > conversations.Length)
        {
            return; //don't show dialogue if there aren't any left. could have default message here
        }
        inkManager.SetDialogue(conversations[numberOfInteractions]);
        numberOfInteractions++;
    }
}
