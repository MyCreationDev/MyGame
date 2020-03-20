using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ResourceGebäude : BasicGebäude
{
    private Timer ProductionTimer = new Timer();
    public int ProductionIntervall;

    // Start is called before the first frame update
    public void Start()
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
