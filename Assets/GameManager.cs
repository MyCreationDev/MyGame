using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI WoodDisplay;
    public TextMeshProUGUI StoneDisplay;
    public TextMeshProUGUI WoodPlanksDisplay;

    private int _productionIntervall = 1000;

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

        woodAmout += GlobalVariables.WoodProduction;
        stoneAmout += GlobalVariables.StoneProduction;

        WoodDisplay.text = woodAmout.ToString();
        StoneDisplay.text = stoneAmout.ToString();
        CalculateCraftings();
    }

    private void CalculateCraftings()
    {
        
    }
}
