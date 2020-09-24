using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMop : MonoBehaviour
{
    bool isCleaning = true; //if action is taking place

    Quaternion angle; //angle of mop
    float startingAngle; //starting angle of mop
    float currentAngle;
    public float upperBound;
    public float lowerBound; //max angles of rotation for mop

    public float movementMagnitude; //amount and direction of rotation
    bool reachedPeak; //if the rotation has reached either bound

    void Start()
    {
        startingAngle = this.gameObject.transform.rotation.z;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(isCleaning == false)
            {
                StartCoroutine(Clean());
            }
        }

        if(isCleaning == true)
        {
            currentAngle = this.gameObject.transform.rotation.z;

            if(currentAngle == upperBound || currentAngle == lowerBound)
            {
                reachedPeak = true;
            }
            if (reachedPeak)
            {
                movementMagnitude *= -1f;  //reverses direction of rotation when it reaches either bound
                reachedPeak = false;
            }

            angle = Quaternion.Euler(0, 0, currentAngle + movementMagnitude);
            Debug.Log(currentAngle);
            this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, angle, Time.deltaTime);

        }
    }

    IEnumerator Clean()
    {
        isCleaning = true;
        yield break;
    }
}
