using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Linq;
using UnityEngine.Events;

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
        foreach (var RessourceNameToAddInResourcen in getNextLevelInformation("resourceList", "resources").Elements())
        {
            CityResources.Add(new CityInventory() { ResourceName = RessourceNameToAddInResourcen.Name.ToString() });
            Resourcen.Add(new BasicResource() { ResourceName = RessourceNameToAddInResourcen.Name.ToString() });
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


    internal bool TryUseResources(List<goods> needGoods)
    {
        foreach(var good in needGoods)
        {
            BasicResource resource = Resourcen.Find(x => x.ResourceName == good.ProductName);
            if (resource == null)
            {
                Debug.Log($"Resource {good.ProductName} nicht gefunden.");
                return false;
            }
            else
            {
                if (resource.CurrentAmount < good.Amount)
                {
                    Debug.Log($"Nicht genügend Resourcen von {good.ProductName} vorhanden.");
                    return false;
                }
            }
        }
        foreach(var good in needGoods)
        {
            AddResource(good.ProductName, -good.Amount);
        }
        return true;
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
            a.text = GetResourceAmount(a.gameObject.transform.parent.transform.Find("ResourceName").GetComponent<TextMeshProUGUI>().text).ToString();
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
    private XElement list;
    public XElement getNextLevelInformation(string XMLName, string XMLHeaderName, XElement Level = default(XElement))
    {

        var XMLCOMPLETE = getAllXMLInfortmation(XMLName, XMLHeaderName);
        //Debug.Log(XMLCOMPLETE);
        if (Level == default(XElement))
        {
                list = XMLCOMPLETE;
        }
        else
        {
            foreach (var XMLInformation in XMLCOMPLETE.Elements())
            {
                    foreach (var XMLPART in XMLInformation.Elements())
                    {
                        list = XMLPART;
                    }
            }
        } 
        return list;
    }


    //Interface für das Baumenü
    public GameObject BuildManagerGameObject;
    public List<GameObject> Buildings;
    public GameObject TEST;
    public UnityAction buildAction;
    public void buildbuildingInterface()
    {
        foreach(var a in getNextLevelInformation("buildings", "buildings").Elements())
        {
            //Objekte zuweisen!!
            foreach (var i in a.Elements())
            {
                var BuildingGroup = Instantiate(ButtonBuilding, BuildMenuResources);
                BuildingGroup.transform.Find("Text").GetComponent<Text>().text = i.Name.ToString();
                foreach(var c in i.Elements())
                {
                    if(c.Name == "objectname")
                    {
                        foreach(var b in Buildings)
                        {
                            Debug.Log(b.name);
                            if (b.name == c.Value)
                            {
                                BuildingGroup.GetComponent<Button>().onClick.AddListener(delegate { BuildManagerGameObject.GetComponent<BuildManager>().Build(b); });
                                if(!b.GetComponent<woodcuter>())
                                {
                                    b.AddComponent<woodcuter>();
                                }

                            }
                        }
                    }

                    ResourceProductionSystem rps = new ResourceProductionSystem();
                    if (c.Name == "produces")
                    {
                        foreach (var resource in getNextLevelInformation("resourceList", "resources").Elements())
                        {
                            if(resource.Name == c.Value)
                            {
                                foreach (var elem in c.Elements())
                                {
                                    if (elem.Name == "duration")
                                        rps.duration = int.Parse(elem.Value);
                                    if(elem.Name == "produceAmount")
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

/*
public Transform BuildMenuResources;
public GameObject ButtonBuildungGroupName;
public GameObject ButtonBuilding;*/
