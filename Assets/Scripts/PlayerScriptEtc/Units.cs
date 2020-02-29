using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Units : PlayerScripts
{
    public string unitname;
    public float speed;
    public int life;
    public float rangeToAttack;


    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        agent = GetComponent<NavMeshAgent>();
    }


    public bool MoveUnits(Vector3 destination)
    {
        agent.speed = speed;
        agent.SetDestination(destination);
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "D_mo_manicanSword")
        { 
            //gameObject.transform.LookAt(other.gameObject.transform.position);
            attack(other.gameObject);
        }
    }

    public virtual void attack(GameObject Enemy)
    {

    }
}
