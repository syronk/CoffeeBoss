using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public double Amount, Mod;
    public string Name;
    public Stat()
    {
        Amount = 0;
        Name = "null";
        Mod = 0;
    }
    public Stat(string iName, double iAmount)
    {
        Amount = iAmount;
        Name = iName;
        Mod = 0;
    }
}
