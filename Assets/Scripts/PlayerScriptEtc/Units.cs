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
    protected float dist;
    public bool movement;
    [HideInInspector]
    protected NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void MoveUnits(Vector3 destination)
    {
        
        agent.speed = speed;
        agent.SetDestination(destination);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "D_mo_manicanSword")
        { 
            //gameObject.transform.LookAt(other.gameObject.transform.position);
            attack(other.gameObject);
        }
    }

    //Wird in der Childklasse näher beschrieben /überschrieben
    public virtual void attack(GameObject Enemy)
    {

    }
}
