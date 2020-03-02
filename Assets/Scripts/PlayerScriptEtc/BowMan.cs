using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BowMan : Units
{

    public int arrowspeed;
    public GameObject arrow;
    public Transform arrowPosition;
    public float attackspeed;
    
    public GameObject Bow;
    private float lastshot;


    private GameObject focusedEnemy;

    private void Start()
    {
        movement = false;   
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public override void attack(GameObject Enemy)
    {
        base.attack(Enemy);
        focusedEnemy = Enemy;

    }


    // Update is called once per frame
    void Update()
    {
        dist = agent.remainingDistance;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        if(focusedEnemy)
        {
            gameObject.transform.LookAt(focusedEnemy.gameObject.transform.position);
            
            if (Time.time - lastshot >= attackspeed)
            {
                Bow.transform.LookAt(focusedEnemy.gameObject.transform.position);

                Arrow projectile = Instantiate(arrow, arrowPosition.position, arrowPosition.rotation).GetComponent<Arrow>();

                //Pfeil schießt direkt auf das Ziel. Ggf. erst, wenn der Bogenschütze ein höheres Level hat??
                projectile.target = focusedEnemy.gameObject;
                projectile.speed = arrowspeed;
                lastshot = Time.time;
            }
                
        }
        
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    GetComponent<SphereCollider>().enabled = true;
                }
            }
        }
    }
}
