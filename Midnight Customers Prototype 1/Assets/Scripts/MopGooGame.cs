using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopGooGame : MonoBehaviour
{
    public GameObject goo;
    public GameObject mop;

    GameObject miniGameControl;
    MiniGameControl mgC; //game control script on ^

    private void Start()
    {
        miniGameControl = GameObject.Find("Mini Game Control");
        mgC = miniGameControl.GetComponent<MiniGameControl>();

        //send objects to minigame control
    }

    
}
