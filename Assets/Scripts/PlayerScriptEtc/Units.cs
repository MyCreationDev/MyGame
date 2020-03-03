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
    public float noticeEnemyRange;
    protected float dist;
    public bool movement;
    [HideInInspector]
    protected NavMeshAgent agent;


    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        life = 100;
    }
    
    public void MoveUnits(Vector3 destination)
    {
        
        agent.speed = speed;
        agent.SetDestination(destination);
    }


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Units>())
        {
            if (other.gameObject.GetComponent<Units>().playername != "Mike")
            {
                    attack(other.gameObject);
            }
        }
    }

    //Wird in der Childklasse näher beschrieben /überschrieben
    public virtual void attack(GameObject Enemy)
    {

    }

    public void SphereColliderOff()
    {
        GetComponent<SphereCollider>().enabled = false;
    }

    public void SphereColliderOn()
    {
        GetComponent<SphereCollider>().enabled = true;
    }

}
