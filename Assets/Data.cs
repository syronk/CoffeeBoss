using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Data
{
    public Resource stores;
    public Resource subs;
    public Resource pots;
    public Resource espressoM;
    public double citizens;
    public Resource dCases;
    public double money;
    public Stat pastries;
    public Stat beans;
    public Resource ovens;
    public Resource beanBuyer;
    public Resource iceMaker;
    public Resource milkBuyer;
    public Resource steamer;
    public Resource blender;
    public Resource pump;
    public Stat muffins;
    public Stat milk;
    public Stat scones;
    public Stat bagels;
    public Stat ice;
    public Stat syrup;

    public List<Stat> stats;
    public List<Resource> equip;





    public Data()
    {
        money = 100;
        stores = new Resource("Store", 1, 1000);
        pots = new Resource("Brewer", 1, 25);
        subs = new Resource("tests", 0, 5);
        citizens = 5;
        dCases = new Resource("Display Cases", 0, 0);
  
        ovens = new Resource("Oven", 0, 1200);
        espressoM = new Resource("Espresso", 0, 100);
        beanBuyer = new Resource("Bean Buyer", 0, 500);
        milkBuyer = new Resource("+Milk", 0, 1000);
        steamer = new Resource("Steamer", 0, 1000);
        blender = new Resource("Blender", 0, 1000);
        iceMaker = new Resource("+Ice", 0, 1000);
        pump = new Resource("Pump", 0, 1000);

        milk = new Stat("Milk", 0);
        ice = new Stat("Ice", 0);
        syrup = new Stat("Syrup", 0);
        scones = new Stat("Scones", 0);
        muffins = new Stat("Muffins", 0);
        bagels = new Stat("Bagels", 0);
        pastries = new Stat("Pastries", 0);
        beans = new Stat("Beans", 100);

        equip = new List<Resource>();
        equip.Add(stores);
        equip.Add(pots);
        equip.Add(ovens);
        equip.Add(espressoM);
        equip.Add(beanBuyer);
        equip.Add(milkBuyer);
        equip.Add(steamer);
        equip.Add(blender);
        equip.Add(iceMaker);
        equip.Add(pump);

        stats = new List<Stat>();
        stats.Add(beans);
        stats.Add(milk);
        stats.Add(ice);
        stats.Add(syrup);
        stats.Add(muffins);
        stats.Add(bagels);
        stats.Add(scones);

    }

}
