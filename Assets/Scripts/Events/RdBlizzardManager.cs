using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RdBlizzardManager : MonoBehaviour // completely luck based
{
    [SerializeField] private Text rText;
    [SerializeField] private Text moraleDecrease;
    [SerializeField] private Text clothingDecrease;
    [SerializeField] private Text healthDecrease;
    private int moraleLost = 0; 
    private int clothingLost = 0;
    private int healthLost = 0;
    private int strModifier;

    private int diceRoll;

    // SAVE TO GLOBAL CONTROL
    public void SaveChanges()
    {
        // Save morale lost
        GlobalControl.Instance.Morale -= moraleLost;
        if (GlobalControl.Instance.Morale < 0)
        {
            GlobalControl.Instance.Morale = 0;
        }
        Debug.Log("GlobalNewMorale: " + GlobalControl.Instance.Morale);

        // Save clothing lost
        GlobalControl.Instance.Clothing -= clothingLost;
        if (GlobalControl.Instance.Clothing < 0)
        {
            GlobalControl.Instance.Clothing = 0;
        }
        Debug.Log("GlobalNewClothing: " + GlobalControl.Instance.Clothing);

        // Save health lost
        GlobalControl.Instance.Health -= healthLost;
        if (GlobalControl.Instance.Health < 0)
        {
            GlobalControl.Instance.Health = 0;
        }
        Debug.Log("GlobalNewClothing: " + GlobalControl.Instance.Health);

        PlayerPrefs.hero.Health -= healthLost;
        PlayerPrefs.hero.Morale -= moraleLost;
        PlayerPrefs.hero.CheckHealthMorale();
    }

    // Start is called before the first frame update
    void Start()
    {
        // LOAD FROM GLOBAL CONTROL
        strModifier = 0; // FIXME: retrieve str modifier

        // Calculate Roll
        diceRoll = Random.Range(1, 21); // Roll a d20
        diceRoll += strModifier;

        Debug.Log("Blizzard DC: " + diceRoll);
        if (diceRoll >= 10 && diceRoll < 15)    // roll between 10-15
        {
            moraleLost += Random.Range(10, 11);
            clothingLost += Random.Range(10, 16);
            healthLost += 10;
            rText.text = "Remembering your mission, you endure the harsh winds and endless snowfall. " +
                "You eventually reach the end of the blizzard, albeit shivering in pain.";
        }
        else if (diceRoll >= 15 && diceRoll < 20) // roll between 15-20
        {
            moraleLost += 0;
            clothingLost += Random.Range(10, 16);
            healthLost += 5;
            rText.text = "You emulate a titan of strength, and not even the icicles daggers that compose " +
                "the blizzard's wind can stop you. The same can't be said of your clothes though.";
        }
        else if (diceRoll >= 20) // roll 20+
        {
            moraleLost += 0;
            clothingLost += Random.Range(10, 16);
            healthLost += 0;
            rText.text = "You are a titan of strength, and not even the icicles daggers that compose " +
                "the blizzard's frigid winds can stop you. The same can't be said of your clothes though.";
        }
        else // roll less than a 10
        {
            moraleLost += Random.Range(15, 21);
            clothingLost += Random.Range(10, 16);
            healthLost += 20;
            rText.text = "The blizzard's effects take a massive toll on your hope, health and sanity. " +
                "The mountains of Nevermelt are truly a frozen hell for those unprepared.";
        }
        moraleDecrease.text = moraleLost + " Morale lost.";
        clothingDecrease.text = clothingLost + " Clothing lost.";
        healthDecrease.text = healthLost + " Health lost.";
        
        PlayerPrefs.hero.Health -= healthLost;
        PlayerPrefs.hero.Morale -= moraleLost;

        // SAVE TO GLOBAL CONTROL
        SaveChanges();
    }


}
