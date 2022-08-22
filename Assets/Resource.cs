using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public int Amount;
    public int Cost;
    public string Name;
    public int BaseCost;
    public Resource()
    {
        Amount = 0;
        Name = "null";
        Cost = 0;
        BaseCost = 0;
    }
    public Resource(string iName, int iAmount, int iBaseCost)
    {
        this.Amount = iAmount;
        this.Name = iName;
        this.Cost = iBaseCost;
        this.BaseCost = iBaseCost;

    }
}
