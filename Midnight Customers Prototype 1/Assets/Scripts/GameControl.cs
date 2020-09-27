using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl control;

    public Vector3 playerPos; //position of player before scene change
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


    public void LoadMiniGame(string gameName)
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform.position; //saves players position so game knows where to put them on return to store area

        SceneManager.LoadScene(gameName);
        
        
    }

    public void LoadArea(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }
   
}
