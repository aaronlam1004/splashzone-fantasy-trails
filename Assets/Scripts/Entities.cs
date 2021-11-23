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
    protected int hunger;
    protected int sickness;
    protected bool clothes;

    public String Name { get; set; }
    public int Health { get; set; } 
    public int Morale { get; set; }
    public int Hunger { get; set; }
    public int Sickness { get; set; }
    public bool Clothes { get; set; }

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
    protected int strength;
    protected int detexterity;
    protected int intelligence;
    protected int aurum;
    protected int distance;
    protected String description;

    public int HeroType { get; }
    public int Strength { get ; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Aurum { get; set; }
    public int Distance { get; set; }
    public String Description { get; set; }


    public Hero(int htype) : base("Hero")
    {
        this.HeroType = htype;
        switch (htype) {
            case 0:
                this.Strength = 10;
                this.Dexterity = 7;
                this.Intelligence = 5;
                this.Aurum = 100;
                this.Description = "A two handed sword wielder who uses Strength. " +
                "You're a representative of a bordering kingdom ent to help with the " +
                "relief effort.";
                break;
            case 1:
                this.Strength = 7;
                this.Dexterity = 5;
                this.Intelligence = 10; 
                this.Aurum = 75;
                this.Description = "A book user who utilizes Intelligence. " + 
                "You’re a researcher who follows the Elemental Pantheon of this world " +
                "and knows magic from your time studying the elements.";
                break;
            case 2:
                this.Strength = 5;
                this.Dexterity = 10;
                this.Intelligence = 7;
                this.Aurum = 25;
                this.Description = "A dagger user who utilizes Dexterity. " + 
                "You’re a member of a Thieves Guild called the Midnightgarde - " +
                "a notorious spy network wary of the Lich’s plan.";
                break;
        }
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