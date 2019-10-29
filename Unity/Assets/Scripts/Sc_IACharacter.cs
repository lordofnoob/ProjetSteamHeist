using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Free,
    Captured
}

public class Sc_IACharacter : MonoBehaviour
{

    public NavMeshAgent agent;
    public float trialsAreaSize = 5f;

    public Tile IATile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomMovement()
    {
        agent.SetDestination(transform.position + new Vector3(Random.Range(1, trialsAreaSize), 0f, Random.Range(1, trialsAreaSize)));
    }
}
