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

    public List<BasicResource> Resourcen;
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
        Resourcen = new List<BasicResource>();
        Resourcen.Add(new BasicResource() { ResourceName = "Wood"});
        Resourcen.Add(new BasicResource() { ResourceName = "Stone"});
        Resourcen.Add(new BasicResource() { ResourceName = "WoodPlank"});

        Timer ProductionIntervall = new Timer();
        ProductionIntervall.Interval = _productionIntervall;
        ProductionIntervall.Elapsed += UpdateProduction;
        ProductionIntervall.Start();
    }


    // Update is called once per frame
    void Update()
    {
        
    }



    public int GetResourceAmount(string resourceToGet)
    {
        BasicResource resource = Resourcen.Find(x => x.ResourceName == resourceToGet);
        if (resource == null)
            return -1;
        else
        {
            return resource.CurrentAmount;
        }
    }

    public bool TryUseResources(string resourceToUse,int resourceAmount)
    {
        BasicResource resource = Resourcen.Find(x => x.ResourceName == resourceToUse);
        if (resource == null)
        {
            Debug.Log($"Resource {resourceToUse} nicht gefunden.");
            return false;
        }
        else
        {
            if(resource.CurrentAmount > resourceAmount)
            {
                resource.CurrentAmount -= resourceAmount;
                return true;
            }
            {
                Debug.Log($"Nicht genügend Resourcen von {resourceToUse} vorhanden.");
                return false;
            }
        }
    }

    public bool AddResource(string resourceToAdd,int resourceAmount)
    {
        BasicResource resource = Resourcen.Find(x => x.ResourceName == resourceToAdd);
        if (resource == null)
        {
            Debug.Log($"Resource {resourceToAdd} nicht gefunden.");
            return false;
        } else
        {
            if (resource.addAmount(resourceAmount))
                return true;
            else
                return false;
        }
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
