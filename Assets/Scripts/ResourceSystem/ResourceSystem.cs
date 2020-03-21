using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceProductionSystem
{
    public List<goods> Product;
    public int duration;
    public List<goods> NeedGoods;

    public ResourceProductionSystem()
    {
        Product = new List<goods>();
        NeedGoods = new List<goods>();
    }
}
public class goods
{
    public string ProductName;
    public int Amount;
}