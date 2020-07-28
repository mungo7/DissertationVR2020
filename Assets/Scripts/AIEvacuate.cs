﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AIEvacuate : MonoBehaviour

{
    public Transform destinationObject;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        //Ensure that the navMeshAgent variable has a game object attached
        if (navMeshAgent == null)
        {
            Debug.LogError("Nav Mesh Agent is not attached");
        }
        else
        {
            SetDestination();
        }
    }

    //Set the destination of the AI Agent to the position of a specified object within the game environment
    private void SetDestination()
    {
        if (destinationObject != null)
        {
            Vector3 destinationPosition = destinationObject.transform.position;
            navMeshAgent.SetDestination(destinationPosition) ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}