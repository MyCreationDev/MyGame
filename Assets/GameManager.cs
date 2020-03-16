using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Linq;

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
    public List<CityInventory> CityResources;
    public int wood = 0;
    public int stone = 0;
    public int woodPlank = 0;

    public TextMeshProUGUI WoodDisplay;
    public TextMeshProUGUI StoneDisplay;
    public TextMeshProUGUI WoodPlanksDisplay;

    private float _productionIntervall = 0.5f;
    private float _nextProductionUpdate = 0;

    // Start is called before the first frame update
    void Start()
    {
        Resourcen = new List<BasicResource>();
        CityResources = new List<CityInventory>();
        foreach (var RessourceNameToAddInResourcen in getAllRessourcesName())
        {
            CityResources.Add(new CityInventory() { ResourceName = RessourceNameToAddInResourcen });
            Resourcen.Add(new BasicResource() { ResourceName = RessourceNameToAddInResourcen });
        }
        

    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextProductionUpdate)
        {
            _nextProductionUpdate += _productionIntervall;
            UpdateProduction();
        }
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

    private void UpdateProduction()
    {
        WoodDisplay.text = GetResourceAmount("Wood").ToString();
        StoneDisplay.text = GetResourceAmount("Stone").ToString();
        WoodPlanksDisplay.text = GetResourceAmount("WoodPlank").ToString();
    }


    //Alle Informationen aus der XML
    public XElement getAllRessourceInfortmation()
    {
        TextAsset textXMLAsset = Resources.Load<TextAsset>("resourceList");
        var doc = XDocument.Parse(textXMLAsset.text);
        return doc.Element("resources");
    }

    //Alle Namen der vorhanden Ressourcen aus der XML
    public List<string> list;
    public List<string> getAllRessourcesName()
    {
        list = new List<string>();
        foreach (var ressourceSingleName in getAllRessourceInfortmation().Elements())
        {
            list.Add(ressourceSingleName.Name.ToString());
        }
        return list;
    }

}
