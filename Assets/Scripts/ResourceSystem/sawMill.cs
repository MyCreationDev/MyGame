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
        BuildCostStone = 20;
        BuildCostWood = 50;
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
        if(GameManager.Instance.wood > woodCost)
        {
            GameManager.Instance.wood -= woodCost;
            GameManager.Instance.woodPlank += ProductionAmount;
        }
    }
    
}
