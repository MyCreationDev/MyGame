using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Units : PlayerScripts
{
    public string unitname;
    public float speed;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    public bool MoveUnits(Vector3 destination)
    {
        agent.speed = speed;
        agent.SetDestination(destination);
        return true;
    }
}
