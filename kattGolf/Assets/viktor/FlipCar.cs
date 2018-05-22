using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCar : MonoBehaviour
{
    float timeRemaining = 1;
    float timeRemainingReset = 0.5f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        timeRemaining -= Time.deltaTime; // subtract time each frame
        if (timeRemaining <= 0)
        {
            // reset the timer
            timeRemaining = timeRemainingReset;
            // perform your actions (load next scene, move a gameobject, perform garbage clean up etc.)
            //transform.Rotate(Vector3.forward, 90);
            transform.Rotate(90, 0, 0);
            print("iwork");
        }
    }
    
}