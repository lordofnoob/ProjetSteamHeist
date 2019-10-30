﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum HostageState
{
    Free,
    Captured,
    Stocked
}

public class Sc_IAHostage : Mb_Trial
{
    public float stress = 0f; //Percentage
    public Image stressBar;

    public NavMeshAgent agent;
    public float trialsAreaSize = 5f;

    public Tile IATile;

    public HostageState state = HostageState.Free;
    public Player target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Counting();
        if (state == HostageState.Captured)
            FollowTarget();
    }

    public void RandomMovement()
    {
        agent.SetDestination(transform.position + new Vector3(Random.Range(1, trialsAreaSize), 0f, Random.Range(1, trialsAreaSize)));
    }

    public override void DoThings()
    {
        //Debug.Log("TARGET CAPTURED");
        IAManager.Instance.IAHostageFollowingPlayer(this, listOfUser[0]);
        ResetValues();
    }

    void FollowTarget()
    {
        //Debug.Log("FOLLOWING");

        Vector3 targetPos = target.transform.position;
        agent.SetDestination(targetPos);
        agent.stoppingDistance = 2f;
    }
}
