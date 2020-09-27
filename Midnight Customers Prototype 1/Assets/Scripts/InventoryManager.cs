using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    

    public Dictionary<string, int> inventoryItems;

    
   
    void Start()
    {
        if(inventoryItems == null)
        {
            inventoryItems = new Dictionary<string, int>(); //may need to add don't destroy on load or something to keep inventory between scenes
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addItem(string ID, int amount)
    {
        //Adds items to item inventory dictionary
        try
        {
            inventoryItems.Add(ID, amount);  //if item doesn't exist in inventory 
        }
        catch //for when 1 or more of an item already exist in inventory
        {
            inventoryItems[ID] += amount;  //Consider max amount? Inventory space?
        }
    }

    public void useItem(string ID)
    {

        inventoryItems[ID] -= 1;
        if (inventoryItems[ID] < 1)
        {
            inventoryItems.Remove(ID);
        }
        //call item specific function here or elsewhere

    }

    public bool itemCheck(string itemName)
    {
        if (inventoryItems.ContainsKey(itemName))
            return true;
        
        else
            return false;
       
    }
       

}
