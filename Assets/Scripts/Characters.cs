using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person
{
    protected String name;
    protected int health;
    protected int morale;

    public String Name { get; set; }
    public int Health { get; set; } // 0
    public int Morale { get; set; }

    public Person(String personName)
    {
        this.Name = personName;
        this.Health = 100;
        this.Morale = 100;
    }
}

public class Hero : Person
{
    // 0: knight, 1: mage, 2: rouge
    protected int heroType;
    protected int strength; // 1
    protected int mana; // 2
    protected int luck; // 3

    public int HeroType { get; }
    public int Strength { get ; set; }
    public int Mana { get; set; }
    public int Luck { get; set; }

    public Hero(int htype, int heroStrength, int heroMana, int heroLuck) : base("Vanuun")
    {
        this.HeroType = htype;
        this.Strength = heroStrength;
        this.Mana = heroMana;
        this.Luck = heroLuck;
    }

    public String GetHeroType()
    {
        switch (heroType)
        {
            case 0:
                return "Knight";
            case 1:
                return "Mage";
            default:
                return "Rouge";
        }
    }

}