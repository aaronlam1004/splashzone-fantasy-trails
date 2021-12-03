using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RdSlimeManager : MonoBehaviour
{
    [SerializeField] private GameObject resultCanvas;
    [SerializeField] private TextMeshProUGUI rTitle;
    [SerializeField] private TextMeshProUGUI rDesc;
    [SerializeField] private TextMeshProUGUI rHealth;
    [SerializeField] private TextMeshProUGUI rGold;
    [SerializeField] private TextMeshProUGUI rMorale;
    // Roll a d20
    // According to D&D 5e SRD, dice roll difficulties are:
    // -----Task-Difficulty-------DC--
    //      Very easy	          5
    //      Easy	              10
    //      Medium	              15
    //      Hard	              20
    //      Very hard	          25
    //      Nearly impossible	  30
    private int diceRoll;
    private int intModifier = PlayerPrefs.hero.Intelligence / 2;
    private int dexModifier = PlayerPrefs.hero.Dexterity / 2;
    private int strModifier = PlayerPrefs.hero.Strength / 2;

    private bool success;

    private int playerClass; // 0: knight, 1: mage, 2: rouge

    private int goldGained = 0; // GOLD PROPERTY
    private int moraleGained = 0; // MORALE PROPERTY
    private int healthLost = 0; // HEALTH PROPERTY

    // SAVE TO GLOBAL CONTROL
    public void SaveGold()
    {
        GlobalControl.Instance.Aurum += goldGained;
        PlayerPrefs.hero.Aurum += goldGained;
    }
    public void SaveMoraleHealth()
    {
        GlobalControl.Instance.Morale += moraleGained;
        if (GlobalControl.Instance.Morale < 0)
        {
            GlobalControl.Instance.Morale = 0;
        }
        GlobalControl.Instance.Health -= healthLost; // SUBTRACT
        if (GlobalControl.Instance.Health < 0)
        {
            GlobalControl.Instance.Health = 0;
        }

        PlayerPrefs.hero.Health -= healthLost;
        PlayerPrefs.hero.Morale += moraleGained;
        PlayerPrefs.hero.CheckHealthMorale();
    }

    // INITIALIZE HERE
    // Start is called before the first frame update
    // Check for food type
    private void Start()
    {
        // Turn of result canvas initially
        resultCanvas.SetActive(false);

        // LOAD FROM PLAYERPREFS
        playerClass = PlayerPrefs.hero.HeroType;

        // ROLL THE DICE
        diceRoll = Random.Range(1, 21);
        Debug.Log("Slime DC: " + diceRoll);
    }


    public void DirectFight() // Harder Check, More Gold, More Morale
    {
        // playerClass = 2; // FIXME: TESTING ONLY
        // dexModifier = -20; // FIXME: TESTING ONLY

        // Calculate respective modifiers - 0: knight, 1: mage, 2: rouge
        if (playerClass == 0)
        {
            diceRoll += strModifier; // add str modifier
        }
        else if (playerClass == 1)
        {
            diceRoll += intModifier; // add int modifier
        }
        else if (playerClass == 2)
        {
            diceRoll += dexModifier; // add dex modifier
        }
        Debug.Log("Slime DC + Modifier: " + diceRoll);

        if (diceRoll >= 15) { success = true; } // Easier than skeletons
        else { success = false; }

        if (success) // SUCCESS
        {
            healthLost += 0;
            goldGained += Random.Range(25, 31);
            moraleGained += Random.Range(25, 31);

            // Class flavor text - 0: knight, 1: mage, 2: rouge
            if (playerClass == 0)
            {
                rDesc.text = "You charge at the slimes sword in hand. You slice and dice the almost helpless " +
                    "Winterfrost slimes.";
            }
            else if (playerClass == 1)
            {
                rDesc.text = "You blow up the attack slimes with a deftly placed fireball.";
            }
            else if (playerClass == 2)
            {
                rDesc.text = "You throw the perfect amount of daggers that slay the attacking winterfrost slimes";
            }
            else
            {
                Debug.Log("ERROR ERROR ERROR ERROR");
            }

            // LOAD SUCCESS SCREEN
            rTitle.text = "Cool moves, killer!";
            rGold.text = ((int)goldGained).ToString();
            rHealth.text = ((int)healthLost).ToString();
            rMorale.text = ((int)moraleGained).ToString();
            resultCanvas.SetActive(true);

            // LOAD TO GLOBAL CONTROL
            SaveGold();
            SaveMoraleHealth();
        }
        else // FAILURE
        {
            goldGained += -15;
            moraleGained += -Random.Range(10, 16);

            // Class flavor text - 0: knight, 1: mage, 2: rouge
            if (playerClass == 0)
            {
                healthLost += 5;
                rDesc.text = "You lose to the slimes. So much for your knighthood training huh. You retreat " +
                    "for the sake of your remaining honor.";
            }
            else if (playerClass == 1)
            {
                healthLost += 15;
                rDesc.text = "You throw a fireball at the slimef but miss, you're so disappointed in " +
                    "yourself that your run away.";
            }
            else if (playerClass == 2)
            {
                healthLost += 10;
                rDesc.text = "You make a valiant leap towards the slimes, but you fall flat on your face " +
                    "and you decide to run away in disappointment with yourself.";
            }
            else
            {
                Debug.Log("ERROR ERROR ERROR ERROR");
            }

            // LOAD FAILURE SCREEN
            rTitle.text = "The Slimes Succeed!";
            rGold.text = ((int)goldGained).ToString();
            rMorale.text = ((int)moraleGained).ToString();
            rHealth.text = ((int)healthLost).ToString();
            resultCanvas.SetActive(true);

            // LOAD TO GLOBAL CONTROL
            SaveGold();
            SaveMoraleHealth();
        }
    }


    public void EscapeFight()
    {
        // playerClass = 2; // FIXME: TESTING ONLY
        // dexModifier = -10; // FIXME: TESTING ONLY

        diceRoll += dexModifier; // add dex modifier
        Debug.Log("Slime DC + Modifiers: " + diceRoll);

        if (diceRoll >= 5)
        {
            // LOAD FAILURE SCREEN
            moraleGained += -Random.Range(5, 16);
            rTitle.text = "You run away from your problems!";
            rDesc.text = "You run away from the slimes, but can't help feel an aura of " +
                "disappointment emanating from at least one of the villagers.";
            rGold.text = ((int)goldGained).ToString();
            rMorale.text = ((int)goldGained).ToString();
            rHealth.text = ((int)healthLost).ToString();
            resultCanvas.SetActive(true);
        }
        else
        {
            moraleGained += -Random.Range(5, 11);
            healthLost += 5;
            rTitle.text = "You run away from your problems!";
            rDesc.text = "You run away from the slimes, but one of them manages to spit a glob " +
                "of goo on your feet and you trip before getting back up on your feet."; // sickness here?
            rGold.text = ((int)goldGained).ToString();
            rMorale.text = ((int)goldGained).ToString();
            rHealth.text = ((int)healthLost).ToString();
            resultCanvas.SetActive(true);
        }
        // LOAD TO GLOBAL CONTROL
        SaveGold();
        SaveMoraleHealth();
    }
}
