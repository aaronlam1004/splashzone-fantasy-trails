using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person
{
    public String Name { get; set; }
    public int Health { get; set; } 
    public int Morale { get; set; }
    // public int Hunger { get; set; }
    // public int Sickness { get; set; }
    public int Clothes { get; set; }

    public Person(String personName)
    {
        this.Name = personName;
        this.Health = 100;
        this.Morale = 100;
        this.Clothes = 0;
    }
}

public class Hero : Person
{
    public int HeroType { get; } // 0: knight, 1: mage, 2: rogue
    public int Strength { get ; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Aurum { get; set; }
    public String Distance { get; set; }
    public String Description { get; set; }
    public Dictionary<Item, int> Items = new Dictionary<Item, int>();

    public Hero(int htype) : base("Hero")
    {
        this.HeroType = htype;
        switch (htype) {
            case 0:
                this.Strength = 10;
                this.Dexterity = 7;
                this.Intelligence = 5;
                this.Aurum = 300;
                this.Description = "A two handed sword wielder who uses Strength. " +
                "You're a representative of a bordering kingdom sent to help with the " +
                "relief effort.";
                break;
            case 1:
                this.Strength = 7;
                this.Dexterity = 5;
                this.Intelligence = 10; 
                this.Aurum = 250;
                this.Description = "A book user who utilizes Intelligence. " + 
                "You’re a researcher who follows the Elemental Pantheon of this world " +
                "and knows magic from your time studying the elements.";
                break;
            case 2:
                this.Strength = 5;
                this.Dexterity = 10;
                this.Intelligence = 7;
                this.Aurum = 200;
                this.Description = "A dagger user who utilizes Dexterity. " + 
                "You’re a member of a Thieves Guild called the Midnightgarde - " +
                "a notorious spy network wary of the Lich’s plan.";
                break;
        }
    }

    public String GetHeroType()
    {
        switch (this.HeroType)
        {
            case 0:
                return "Knight";
            case 1:
                return "Mage";
            default:
                return "Rogue";
        }
    }

    public void AddItem(Item item, int amount=1)
    {
        try
        {
            Items[item] += amount;
        }
        catch (KeyNotFoundException)
        {
            Items[item] = amount;
        }
    }

    public void UseItem(Item item)
    {
        Items[item] -= 1;
        if (Items[item] == 0)
        {
            Items.Remove(item);
        }
    }

    public void CheckHealthMorale()
    {
        if (this.Health < 0)
        {
            this.Health = 0;
        }

        if (this.Morale < 0)
        {
            this.Morale = 0;
        }
    }
}