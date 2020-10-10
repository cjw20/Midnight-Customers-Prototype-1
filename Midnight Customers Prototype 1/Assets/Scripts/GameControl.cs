﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl control;

    public Vector3 playerPos; //position of player before scene change

    public string dialogueResult; //result of most recent dialogue
    GameObject player;
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetDialougeResult(string result)
    {
        dialogueResult = result;
    }

    public void LoadMiniGame(GameObject miniGame)
    {
        //player = GameObject.FindWithTag("Player");
        //playerPos = player.transform.position; //saves players position so game knows where to put them on return to store area

        Instantiate(miniGame);
        
        
    }

    public void LoadArea(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }
   
}
