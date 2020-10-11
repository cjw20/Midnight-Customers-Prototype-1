using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockingMinigame : MonoBehaviour
{
    public GameObject[] emptySpots;
    int numberOfSpots;

    // Start is called before the first frame update
    void Start()
    {
        numberOfSpots = emptySpots.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCount()
    {
        numberOfSpots--;
        if(numberOfSpots < 1)
        {
            Destroy(this.gameObject); //closes minigame after each shelf has been stocked
        }
    }
}
