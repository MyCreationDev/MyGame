using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ResourceGebäude : BasicGebäude
{
    private Timer ProductionTimer = new Timer();
    public int ProductionIntervall;
    public int ProductionAmount;

    // Start is called before the first frame update
    void Start()
    {
        ProductionTimer.Interval = ProductionIntervall;
        ProductionTimer.Elapsed += GenerateResource;
        ProductionTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void GenerateResource(object sender, ElapsedEventArgs e)
    {        
    }
}
