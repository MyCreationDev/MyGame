using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class sawMill : ResourceGebäude
{


    public int woodCost = 2;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        BuildCosts.Add("Wood", 50);
        BuildCosts.Add("Wood", 20);
        ProductionAmount = 5;
        ProductionIntervall = 5000;
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected override void GenerateResource(object sender, ElapsedEventArgs e)
    {
        base.GenerateResource(sender, e);
        if(GameManager.Instance.GetResourceAmount("Wood") >= woodCost)
        {
            GameManager.Instance.TryUseResources("Wood", woodCost);
            GameManager.Instance.AddResource("WoodPlank", ProductionAmount);
        }
    }
    
}
