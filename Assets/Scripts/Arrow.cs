using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public int speed;
    public GameObject target;
    public int damage;

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
            collision.gameObject.GetComponent<Units>().gettingDamage(damage);            
        }
        Destroy(gameObject);
    }
}
