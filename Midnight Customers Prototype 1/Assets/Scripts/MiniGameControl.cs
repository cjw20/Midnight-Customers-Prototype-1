using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MiniGameControl : MonoBehaviour
{
   
    public UIController uiController;

    GameObject miniGame; //minigame to be played
    public Camera mainCamera; //store camera
    public Camera miniCamera; //camera for minigame

    bool cameraSwitch = true;

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
        SwitchCam();
    }
    public void SwitchCam()
    {

        //switches which camera is active
        cameraSwitch = !cameraSwitch;
        mainCamera.gameObject.SetActive(cameraSwitch);
        miniCamera.gameObject.SetActive(!cameraSwitch);
    }
    
}
