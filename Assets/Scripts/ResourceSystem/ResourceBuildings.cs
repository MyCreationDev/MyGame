using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class ResourceBuildings : ResourceGebäude
{

    public List<ResourceProductionSystem> production;
    public List<goods> products;
    public List<goods> consumption;


    private void Start()
    {
        var list = new List<string>();
        products = new List<goods>();
        production = new List<ResourceProductionSystem>();
        consumption = products;

        products.Add(new goods { ProductName = "woodPlanks", Amount = 1 });
        consumption.Add(new goods {ProductName = "wood", Amount = 2 });
        production.Add(new ResourceProductionSystem { Product = products, duration = 2, NeedGoods = consumption });
    }
}
