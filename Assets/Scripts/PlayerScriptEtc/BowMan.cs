using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMan : Units
{

    public int arrowspeed;
    public GameObject arrow;
    public Transform arrowPosition;
    public float attackspeed;

    public GameObject Bow;
    private float lastshot;


    private GameObject focusedEnemy;


    public override void attack(GameObject Enemy)
    {
        base.attack(Enemy);
        focusedEnemy = Enemy;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(focusedEnemy)
        {
            gameObject.transform.LookAt(focusedEnemy.gameObject.transform.position);
            
            if (Time.time - lastshot >= attackspeed)
            {
                Bow.transform.LookAt(focusedEnemy.gameObject.transform.position);
                Arrow projectile = Instantiate(arrow, arrowPosition.position, arrowPosition.rotation).GetComponent<Arrow>();
                projectile.speed = arrowspeed;
                lastshot = Time.time;
            }
                
        }
    }
}
