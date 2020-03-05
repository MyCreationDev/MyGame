using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public Transform Target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        var UnitsToAttack = GameObject.Find("woodcuter (1)");
        Target = UnitsToAttack.transform;
    }

    // Update is called once per frame
    void Update()
    {

        //Target = GameObject.Find("D_mo_manicanBow").transform;
        if(Target)
            agent.SetDestination(Target.position);
    }
}
