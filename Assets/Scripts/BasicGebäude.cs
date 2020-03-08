using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGebäude : PlayerScripts
{
    public Dictionary<string, int> BuildCosts = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool CanBuyBuilding()
    {
        foreach(var resourceCost in BuildCosts)
        {
            if (GameManager.Instance.GetResourceAmount(resourceCost.Key) < resourceCost.Value)
                return false;
        }
        return true;
    }
    
    public void BuyBuilding()
    {
        foreach (var resourceCost in BuildCosts)
        {
            GameManager.Instance.TryUseResources(resourceCost.Key, resourceCost.Value);
        }
    }
}
