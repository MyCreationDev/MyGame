﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using UnityEngine.UI;

public class MarketPlace : MonoBehaviour
{
    //Marktplatzbestand
    public int woodAmount;
    public int stoneAmount;


    //StadtinventarVariablen
    private float timer = 0;

    private void Update()
    {

        timer += Time.deltaTime;
        
        if(timer >= 30f)
        {
            woodAmount = Mathf.RoundToInt(Random.Range(-3f, 3f));
            timer = 0;
        }

    }


    public string getRessourceInformation(string resource, string information)
    {
        var alldict = GameManager.Instance.getAllXMLInfortmation("resourceList", "resources").Elements();
        foreach (var oneDict in alldict)
        {
            if (oneDict.Name == resource)
            {
                foreach (var singleDict in oneDict.Elements(information))
                {
                    //Abgefragten Wert zurückgeben
                    //Debug.Log(singleDict.Value);
                    return singleDict.Value;
                }
            }
        }
        return "";
    }
    

}
