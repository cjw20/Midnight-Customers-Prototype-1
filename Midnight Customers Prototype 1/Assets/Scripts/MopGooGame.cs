using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopGooGame : MonoBehaviour
{
    public GameObject goo;
    public GameObject mop;

    public GameObject mopSpawn;


    private void Start()
    {

        Instantiate(mop, mopSpawn.transform);

        //instantiate neccessary objects
    }

    
}
