using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handbook : MonoBehaviour
{
    public GameObject openBook;
    bool open = false; //false if closed
  
    private void OnMouseDown()
    {
        open = !open;
        openBook.SetActive(open);
        
    }

   
}
