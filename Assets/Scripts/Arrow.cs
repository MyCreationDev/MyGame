using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int speed;
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            gameObject.transform.LookAt(target.transform.position);
        }
        gameObject.transform.position += transform.forward * Time.deltaTime * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("TREFFER");
        Units EnemyHit = collision.gameObject.GetComponent<Units>();
        if(EnemyHit)
        {
            collision.gameObject.GetComponent<Units>().life -= 20;
            if(EnemyHit.life <= 0)
            {
                //Killfunktion
                Destroy(EnemyHit.gameObject);
            }
        }
        Destroy(gameObject);
    }
}
