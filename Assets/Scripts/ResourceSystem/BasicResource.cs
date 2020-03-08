using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicResource : MonoBehaviour
{
    public int CurrentAmount;
    public int Limit;
    public string ResourceName;

    private void Start()
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
