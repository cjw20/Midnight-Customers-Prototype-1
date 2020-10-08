using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopGooGame : MonoBehaviour
{
    public GameObject goo;
    

    public GameObject[] gooSpawns;

    int remainingGoo = 0;

    public GameObject gameControl;
    GameControl gc;

    private void Start()
    {
        gameControl = GameObject.Find("Game Control");
        gc = gameControl.GetComponent<GameControl>();

        foreach (GameObject gooSpawn in gooSpawns)
        {
            Instantiate(goo, gooSpawn.transform);
            remainingGoo++;
        }
        //instantiate neccessary objects
    }

    private void Update()
    {
        if(remainingGoo < 1)
        {
            // gc.LoadArea("Store");  //create not hard coded way later?
            Destroy(this.gameObject);
        }
    }

    public void UpdateGooCount(int change) //change is how many goo to add/subtract
    {
        remainingGoo += change;
    }


}
