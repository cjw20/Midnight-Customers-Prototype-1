using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCustomer : MonoBehaviour
{

    public GameObject goo;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LeaveGoo", 2f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LeaveGoo()
    {
        Instantiate(goo,this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
