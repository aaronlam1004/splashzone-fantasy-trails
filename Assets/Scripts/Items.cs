using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item 
{
    public String name;
    public String flavorText;
    public int category; // 0 strength, 1 dexterity, 2 intelligence, 3 morale, 4 health, -1
    public int boost;

    public Item(String n, String flavor, int categoryBoosted, int amount)
    {
        name = n;
        flavorText = flavor;
        category = categoryBoosted;
        boost = amount;
    }
}

public static class Items
{
    public static Item[] clothes = new Item[] {
        new Item("Ugly Nondenominational Holiday Sweater", "Knitted with love", -1, 0)
    };
} 
