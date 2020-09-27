using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MiniGameControl : MonoBehaviour
{
   
    public UIController uiController;

    GameObject miniGame; //minigame to be played
 

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
        miniGame = Instantiate(game, this.gameObject.transform);
       
    }
  
}
