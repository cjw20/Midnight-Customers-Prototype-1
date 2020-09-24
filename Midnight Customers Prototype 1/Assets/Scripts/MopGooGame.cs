using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopGooGame : MonoBehaviour
{
    public GameObject goo;
    public GameObject mop;

    GameObject gameMop; //instance of mop present ingame

    public GameObject mopSpawn;


    private void Start()
    {

        gameMop = Instantiate(mop, mopSpawn.transform);

        //instantiate neccessary objects
    }

    
}
