using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class woodcuter : ResourceGebäude
{

    private void Start()
    {
        ProductionAmount = 5;
        ProductionIntervall = 2000;
        base.Start();
    }
    protected override void GenerateResource(object sender, ElapsedEventArgs e)
    {
        base.GenerateResource(sender, e);
        GameManager.Instance.AddResource("Wood",ProductionAmount);

    }
}
