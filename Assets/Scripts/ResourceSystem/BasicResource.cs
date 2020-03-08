using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicResource
{
    public int CurrentAmount;
    public int Limit;
    public string ResourceName;

    public BasicResource()
    {
        Limit = 1000;
    }

    internal bool addAmount(int amount)
    {
        if(CurrentAmount+ amount< Limit)
        {
            CurrentAmount += amount;
            return true;
        }else
        {
            Debug.Log($"Nicht genügend Kapazitäten verfügbar um {amount} {ResourceName} hinzuzufügen.");
            return false;
        }
    }
}
