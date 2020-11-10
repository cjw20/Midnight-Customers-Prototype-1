using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handbook : MonoBehaviour
{
    public GameObject openBook;
    bool open = false; //false if closed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        open = !open;
        openBook.SetActive(open);
        
    }

   
}
