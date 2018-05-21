﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavMeshTest : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public Transform[] points;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    float timeLeft;


    void Start()
    {
        Time.timeScale = 2;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        GotoNextPoint();

    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        //destPoint = (destPoint + 1) % points.Length;
        destPoint = Random.Range(0, points.Length);
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.   points[Random.Range(0, points.Length)]
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
            /*Instantiate(objectToSpawn, spawnPoint, true);
            Destroy(this.gameObject);*/

        }

    }
}