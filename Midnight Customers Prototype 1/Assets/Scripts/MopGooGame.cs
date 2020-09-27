using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopGooGame : MonoBehaviour
{
    public GameObject goo;
    

    GameObject gameMop; //instance of mop present ingame

    public GameObject[] gooSpawns;

    public GameObject mopSpawn;


    private void Start()
    {

        

        foreach(GameObject gooSpawn in gooSpawns)
        {
            Instantiate(goo, gooSpawn.transform);
        }
        //instantiate neccessary objects
    }

    
}
