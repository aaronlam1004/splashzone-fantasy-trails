using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RdWolvesManager : MonoBehaviour // completely luck based
{
    [SerializeField] private Text rText;
    [SerializeField] private Text foodDecrease;
    [SerializeField] private Text moraleDecrease;
    private int moraleLost = 0; // MORALE PROPERTY
    private int foodLost = 0;
    // private int clothingLost = 0;

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

        // Save food lost
        GlobalControl.Instance.Food -= foodLost;
        if (GlobalControl.Instance.Food < 0)
        {
            GlobalControl.Instance.Food = 0;
        }
        Debug.Log("GlobalNewFood: " + GlobalControl.Instance.Food);
    }

    // Start is called before the first frame update
    void Start()
    {
        diceRoll = Random.Range(1, 21); // Roll a d20
        Debug.Log("Wolves DC: " + diceRoll);
        if (diceRoll >= 5 && diceRoll < 15)    // roll between 5-15
        {
            moraleLost += Random.Range(10, 11);
            foodLost += Random.Range(10, 15);
            rText.text = "Under the shadow of night, a pack of wolves ransacks your encampment for " +
                "food, but you awake soon enough to drive them away.";
        }
        else if (diceRoll >= 15 && diceRoll < 20) // roll between 15-20
        {
            moraleLost += Random.Range(5, 11);
            foodLost += Random.Range(5, 11);
            rText.text = "Under the shadow of night, wolves attack your encampment for food, " +
                "but you are quick enough on your feet to light a fire that drives them away.";
        }
        else if (diceRoll >= 20) // roll 20+
        {
            moraleLost += 0; // no loss
            foodLost += 0;
            rText.text = "In a stroke of pure luck, you awake just in time to establish an imposing " +
                "presence via a menacing roar that drives your would-be attackers away.";
        }
        else // roll less than a 5
        {
            moraleLost += Random.Range(15, 21);
            foodLost += Random.Range(20, 26);
            rText.text = "Luck was not on your side today as the wolves ransacked your encampment " +
                "with ease as you stumbled in the dark of night.";
        }
        foodDecrease.text = foodLost + " Food lost.";
        moraleDecrease.text = moraleLost + " Morale lost.";

        // SAVE TO GLOBAL CONTROL
        SaveChanges();
    }


}
