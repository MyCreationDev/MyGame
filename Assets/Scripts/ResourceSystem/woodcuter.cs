using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class woodcuter : ResourceGebäude
{

    public int te;

    private void Awake()
    {
        /*
        var list = new List<string>();
        products = new List<goods>();
        production = new List<ResourceProductionSystem>();
        consumption = products;


        products.Add(new goods { ProductName = "Wood", Amount = 4 });
        consumption.Add(new goods { ProductName = "Wood", Amount = 5 });
        production.Add(new ResourceProductionSystem { Product = products, duration = 500, NeedGoods = consumption});
        Production = production[0];*/

        Debug.Log(Production);
        ProductionIntervall = Production.duration;
        base.Start();
    }

    protected override void GenerateResource(object sender, ElapsedEventArgs e)
    {
        if (Production.NeedGoods.Count > 0)
        {
            if (GameManager.Instance.TryUseResources(Production.NeedGoods))
            {
                foreach (goods b in Production.NeedGoods)
                {
                    GameManager.Instance.AddResource(b.ProductName, b.Amount *-1);
                }
                foreach (goods a in Production.Product)
                {
                    GameManager.Instance.AddResource(a.ProductName, a.Amount);
                }
            }
        }
        else
        {
            foreach (goods a in Production.Product)
            {
                GameManager.Instance.AddResource(a.ProductName, a.Amount);
            }
        }
        
    }
}
