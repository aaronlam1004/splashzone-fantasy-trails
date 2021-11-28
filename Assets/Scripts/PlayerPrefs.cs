using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefs
{
    public static Hero hero = new Hero(0);
    public static Person[] villagers = {
        new Person("Villager 1"),
        new Person("Villager 2"),
        new Person("Villager 3"),
        new Person("Villager 4")
    };
}
