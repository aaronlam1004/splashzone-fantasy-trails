using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item 
{
    public String Name { get; }
    public String FlavorText { get; }
    public int Category { get; } // 0 strength, 1 dexterity, 2 intelligence, 3 morale, 4 health, -1
    public int Boost { get; }
    public int Price { get; }

    public Item(String name, String flavor, int categoryBoosted, int boostedAmount, int price)
    {
        this.Name = name;
        this.FlavorText = flavor;
        this.Category = categoryBoosted;
        this.Boost = boostedAmount;
        this.Price = price;
    }
}

public static class Items
{
    public static int itemCount = 11;

    public static Item[] items = new Item[] {
        new Item("Ugly Nondenominational Holiday Sweater", "Knitted with love", 5, 2, 50),
        new Item("Itchy Cloak", "Not knitted with love", 5, 2, 50),
        new Item("Sleek Boots", "Made for walking", 5, 2, 50),

        new Item("Stinky Berry", "Looks suspiciously like Durian, a fruit from a distant realm you've heard of.\n\n+5 Health", 4, 5, 10),
        new Item("Prickly Plant Juice", "It's the quenchiest!\n\n+5 Health", 4, 5, 10),
        new Item("Rainbow Corn", "Fills you with pride.\n\n+10 Health", 4, 10, 20),
        new Item("Meat...", "This is technically flavor text.\n\n+10 Health", 4, 10, 20),

        new Item("Potion of Gains", "Stop Grinding?!?1? The Grind Never Stops. No Breaks.\n\n+1 Strength", 0, 1, 50),
        new Item("Potion of Haste", "You are speed.\n\n+1 Dexterity", 1, 1, 50),
        new Item("Potion of Common Sense", "Not many people have it.\n\n+1 Intelligence", 2, 1, 50),

        new Item("White Thaw", "Why are we drinking White Thaw? Because the Thaw is the law.™ Bottled in Nevermelt.\n\n+1 Morale", 3, 1, 25)
    };

    public static Item getItemByName(String name)
    {
        for (int i = 0; i < itemCount; i++)
        {
            if (items[i].Name == name)
            {
                return items[i];
            }
        }
        return null;
    }
} 
