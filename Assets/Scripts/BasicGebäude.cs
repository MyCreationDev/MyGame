using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGebäude : PlayerScripts
{
    public int BuildCostStone = 0;
    public int BuildCostWood = 0;
    public int BuildCostWoodPlank = 0;

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
        if(BuildCostWood >= GameManager.Instance.wood &&
            BuildCostStone >= GameManager.Instance.stone &&
            BuildCostWoodPlank >= GameManager.Instance.woodPlank)
        {
            return true;
        }
        return false;
    }
    
    public void BuyBuilding()
    {
        GameManager.Instance.wood -= BuildCostWood;
        GameManager.Instance.stone -= BuildCostStone;
        GameManager.Instance.woodPlank -= BuildCostWoodPlank;
    }
}
