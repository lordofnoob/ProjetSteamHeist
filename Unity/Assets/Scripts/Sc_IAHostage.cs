using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum HostateState
{
    Free,
    Captured,
    Stocked
}

public class Sc_IAHostage : Mb_Trial
{

    public NavMeshAgent agent;
    public float trialsAreaSize = 5f;

    public Tile IATile;

    public HostateState state = HostateState.Free;
    public Player target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Counting();
        if (state == HostateState.Captured)
            FollowTarget();
    }

    public void RandomMovement()
    {
        agent.SetDestination(transform.position + new Vector3(Random.Range(1, trialsAreaSize), 0f, Random.Range(1, trialsAreaSize)));
    }

    public override void DoThings()
    {
        //Debug.Log("TARGET CAPTURED");
        target = listOfUser[0];
        state = HostateState.Captured;
    }

    void FollowTarget()
    {
        //Debug.Log("FOLLOWING");

        Vector3 targetPos = target.transform.position;
        agent.SetDestination(targetPos);
        agent.stoppingDistance = 2f;
    }
}
