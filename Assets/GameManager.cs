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

    //BuildMenue variables
    public Transform BuildMenuResources;
    public GameObject ButtonBuildungGroupName;
    public GameObject ButtonBuilding;
    

    private float _productionIntervall = 0.5f;
    private float _nextProductionUpdate = 0;

    private List<TextMeshProUGUI> ResourceDisplays;
    public Transform ResourceDisplayPanel;
    public GameObject ResourceDisplay;
    // Start is called before the first frame update
    void Start()
    {
        //Inventar für Spieler und Stadt instanziieren.
        Resourcen = new List<BasicResource>();
        CityResources = new List<CityInventory>();
        foreach (var RessourceNameToAddInResourcen in getNextLevelInformation("resourceList", "resources"))
        {
            CityResources.Add(new CityInventory() { ResourceName = RessourceNameToAddInResourcen });
            Resourcen.Add(new BasicResource() { ResourceName = RessourceNameToAddInResourcen });
        }

        ResourceDisplays = new List<TextMeshProUGUI>();
        //Angezeigtes SpielerInventar erstellen
        foreach(var a in Resourcen)
        {
            var ResourceDisplayed = Instantiate(ResourceDisplay, ResourceDisplayPanel);
            ResourceDisplayed.transform.Find("ResourceName").GetComponent<TextMeshProUGUI>().text = a.ResourceName;
            ResourceDisplayed.transform.Find("ResourceAmount").GetComponent<TextMeshProUGUI>().text = a.CurrentAmount.ToString();
            ResourceDisplays.Add(ResourceDisplayed.transform.Find("ResourceAmount").GetComponent<TextMeshProUGUI>());
        }

        //Create BuildingUI
        buildbuildingInterface();
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
        foreach(var a in ResourceDisplays)
        {

            Debug.Log(a.transform.parent.transform.Find("ResourceName").GetComponent<Text>().text);
            a.text = GetResourceAmount(a.transform.parent.transform.Find("ResourceName").GetComponent<Text>().text).ToString();
        }
        /*
        WoodDisplay.text = GetResourceAmount("Wood").ToString();
        StoneDisplay.text = GetResourceAmount("Stone").ToString();
        WoodPlanksDisplay.text = GetResourceAmount("WoodPlank").ToString();*/
    }


    //Alle Informationen aus der XML
    public XElement getAllXMLInfortmation(string XMLName, string XMLHeaderName)
    {
        TextAsset textXMLAsset = Resources.Load<TextAsset>(XMLName);
        var doc = XDocument.Parse(textXMLAsset.text);
        return doc.Element(XMLHeaderName);
    }

    //Alle Namen der vorhanden Ressourcen aus der XML
    private List<string> list = new List<string>();
    public List<string> getNextLevelInformation(string XMLName, string XMLHeaderName, string Level = default(string))
    {
        list = new List<string>();
        var XMLCOMPLETE = getAllXMLInfortmation(XMLName, XMLHeaderName);
        if (Level == default(string))
        {
            foreach (var XMLInformation in XMLCOMPLETE.Elements())
            {
                list.Add(XMLInformation.Name.ToString());
            }
        }
        else
        {
            foreach (var XMLInformation in XMLCOMPLETE.Elements())
            {
                if (XMLInformation.Name == Level)
                {
                    foreach (var XMLPART in XMLInformation.Elements())
                    {
                        list.Add(XMLPART.Name.ToString());
                    }
                    
                }
                
            }
        } 
        return list;
    }

    public GameObject BuildManagerGameObject;
    public List<GameObject> Buildings;
    public GameObject TEST;
    public void buildbuildingInterface()
    {
        foreach(var a in getNextLevelInformation("buildings", "buildings"))
        {
            
            foreach (string i in getNextLevelInformation("buildings", "buildings",a.ToString()))
            {
                var BuildingGroup = Instantiate(ButtonBuilding, BuildMenuResources);
                BuildingGroup.transform.Find("Text").GetComponent<Text>().text = i;
                //Eine Liste mit allen GameObject. Daraus das mit dem Wert i suchen und in 'Build()' einfügen.
                //BuildingGroup.GetComponent<Button>().onClick.AddListener(BuildManagerGameObject.GetComponent<BuildManager>().Build(TEST)); // += BuildManagerGameObject.GetComponent<BuildManager>().Build(TEST);
            }
        }
        
        
    }
    public void blssa()
    {
        Debug.Log("sd");
    }
}

/*
public Transform BuildMenuResources;
public GameObject ButtonBuildungGroupName;
public GameObject ButtonBuilding;*/
