using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sawMill : MonoBehaviour
{
    private int amount;
    private float lastprocessed;

    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.WoodProduction += 5;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //public void proceed(string produces)
    //{
    //    lastprocessed += Time.deltaTime;

    //    if (getResourceAmount("wood") >= 2 && lastprocessed >= timeNeedForProcess)
    //    {

    //        changeResource("wood", -2);
    //        changeResource(produces, 1);
    //        lastprocessed = 0;
    //    }
    //}

    //public void changeResource(string resource, int amount)
    //{
        
    //    GameObject.Find(resource+"Amount").GetComponent<UnityEngine.UI.Text>().text = (int.Parse(GameObject.Find(resource + "Amount").GetComponent<UnityEngine.UI.Text>().text) + amount).ToString();
    //}

    
    
    //int getResourceAmount(string resource)
    //{

    //    return amount;
    //}
}
