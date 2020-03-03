using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Singleton ansatz um zu garantieren dass nur ein Gamemanager exisitert.
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public int wood = 0;
    public int stone = 0;
    public int woodPlank = 0;

    public TextMeshProUGUI WoodDisplay;
    public TextMeshProUGUI StoneDisplay;
    public TextMeshProUGUI WoodPlanksDisplay;

    private int _productionIntervall = 500;

    // Start is called before the first frame update
    void Start()
    {
        Timer ProductionIntervall = new Timer();
        ProductionIntervall.Interval = _productionIntervall;
        ProductionIntervall.Elapsed += UpdateProduction;
        ProductionIntervall.Start();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateProduction(object sender, ElapsedEventArgs e)
    {      
        WoodDisplay.text = wood.ToString();
        StoneDisplay.text = stone.ToString();
        WoodPlanksDisplay.text = woodPlank.ToString();
    }

    public void updateResources()
    {

    }
}
