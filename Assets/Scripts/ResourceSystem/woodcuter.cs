using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class woodcuter : ResourceGebäude
{
    public ResourceProductionSystem Production;   
    private void Start()
    {
        ProductionIntervall = Production.duration;
        base.Start();
    }
    protected override void GenerateResource(object sender, ElapsedEventArgs e)
    {
        GameManager.Instance.TryUseResources(Production.NeedGoods);
        foreach (var a in Production.Product)
        {
            GameManager.Instance.AddResource(a.ProductName, a.Amount);
        }
    }
}
