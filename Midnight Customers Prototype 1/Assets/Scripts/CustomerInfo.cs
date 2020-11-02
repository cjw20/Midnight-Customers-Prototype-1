using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInfo : MonoBehaviour
{
    public string customerName; //name of customer to appear in dialogue window
    public GameObject[] boughtItems; //array of items that customer bought
    public Sprite portrait; //portrait to appear in checkout window

    public string greetingMessage; //first thing customer says
    public string[] greetingResponses; //options for player to respond with

    public string goodbyeMessage;
    public string[] goodbyeResponses;

    public int conversationLength; //how many lines customer has


}
