﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MiniGameControl : MonoBehaviour
{
    public List<GameObject> minigameObjects; //objects that will need to be instantiated for minigame
    public GameObject minigame; //controller of minigame
    public UIController uiController;
    GameObject minigameWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGame(GameObject game)
    {
        //gets minigame from interactableitem script
        minigame = game;
    }
    public void LoadMiniGame()
    {

    }

    public void CloseMiniGame()
    {
        //close minigame
    }
}
