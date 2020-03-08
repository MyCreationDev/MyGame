using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class StoneMine : ResourceGebäude
{
    // Start is called before the first frame update
    void Start()
    {
        BuildCosts.Add("Wood", 20);
    }

    protected override void GenerateResource(object sender, ElapsedEventArgs e)
    {
        base.GenerateResource(sender, e);
        GameManager.Instance.AddResource("Stone", ProductionAmount);
    }
}
