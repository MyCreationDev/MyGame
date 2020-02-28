using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text WoodDisplay;
    public Text StoneDisplay;
    public Text WoodPlanksDisplay;

    private int _productionIntervall = 3000;

    // Start is called before the first frame update
    void Start()
    {
        Timer ProductionIntervall = new Timer();
        ProductionIntervall.Interval = _productionIntervall;
        ProductionIntervall.Elapsed += CalculateProduction;
        ProductionIntervall.Start();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void CalculateProduction(object sender, ElapsedEventArgs e)
    {
        int woodAmout = int.Parse(WoodDisplay.text);
        int stoneAmout = int.Parse(StoneDisplay.text);
        int woodPlankAmout = int.Parse(WoodPlanksDisplay.text);

        woodAmout += GlobalVariables.WoodProduction;
        stoneAmout += GlobalVariables.StoneProduction;
        woodPlankAmout += GlobalVariables.WoodPlankProduction;

        WoodDisplay.text = woodAmout.ToString();
        StoneDisplay.text = stoneAmout.ToString();
        WoodPlanksDisplay.text = woodPlankAmout.ToString();
    }

}
