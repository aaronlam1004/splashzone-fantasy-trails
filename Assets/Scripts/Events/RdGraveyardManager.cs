using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RdGraveyardManager : MonoBehaviour
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
    private int intModifier;
    private int dexModifier;
    private int strModifier;

    private bool success;

    private int playerClass; // 0: knight, 1: mage, 2: rouge

    private int goldGained = 0; // GOLD PROPERTY
    private int moraleGained = 0; // MORALE PROPERTY
    private int healthLost = 0; // HEALTH PROPERTY

    // SAVE TO GLOBAL CONTROL
    public void SaveGold()
    {
        GlobalControl.Instance.Aurum += goldGained;
        Debug.Log("GlobalNewGold: " + GlobalControl.Instance.Aurum);
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
        Debug.Log("GlobalNewHealth: " + GlobalControl.Instance.Morale);
        Debug.Log("GlobalNewHealth: " + GlobalControl.Instance.Health);
    }

    // INITIALIZE HERE
    // Start is called before the first frame update
    // Check for food type
    private void Start()
    {
        // Turn of result canvas initially
        resultCanvas.SetActive(false);

        // LOAD FROM GLOBAL CONTROL
        playerClass = GlobalControl.Instance.Class;
        intModifier = 0; // FIXME: retrieve int modifier
        dexModifier = 0; // FIXME: retrieve dex modifier 
        strModifier = 0; // FIXME: retrieve str modifier 

        // ROLL THE DICE
        diceRoll = Random.Range(1, 21);
        Debug.Log("Grave DC + Modifier: " + diceRoll);
    }


    public void DirectFight() // Harder Check, More Gold, More Morale
    {
        playerClass = 2; // FIXME: TESTING ONLY
        dexModifier = -20; // FIXME: TESTING ONLY

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
        Debug.Log("Grave DC + Modifier: " + diceRoll);

        if (diceRoll >= 15) { success = true; }
        else { success = false; }

        if (success) // SUCCESS
        {
            healthLost += 0;
            goldGained += Random.Range(25, 31);
            moraleGained += Random.Range(25, 31);

            // Class flavor text - 0: knight, 1: mage, 2: rouge
            if (playerClass == 0)
            {
                rDesc.text = "You charge at the skeletons sword in hand. You shatter their ribs and " +
                    "break their legs and you grind them into a nice bonemeal. Life will be born " +
                    "from the ashes of your foe. You smile.";
            }
            else if (playerClass == 1)
            {
                rDesc.text = "You charge at the skeletons and release a ray of fire from your hands towards " +
                    "the undead. Your foes disintegrate to nothing before they can react. Ah, the smile of " +
                    "fire, your favorite.";
            }
            else if (playerClass == 2)
            {
                rDesc.text = "You launch yourself into the air and into the crowd of skeleton warriors and " +
                    "let out a dance of fine bladework around you. By the time you open your eyes, only " +
                    "the pieces of your skeletal foes remain on the ground.";
            }
            else
            {
                Debug.Log("ERROR ERROR ERROR ERROR");
            }

            // LOAD SUCCESS SCREEN
            rTitle.text = "You're a born Killer!";
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
            goldGained += 0;
            moraleGained += -Random.Range(10, 16);

            // Class flavor text - 0: knight, 1: mage, 2: rouge
            if (playerClass == 0)
            {
                healthLost += 10;
                rDesc.text = "You may have overestimated your abilities by jumping head first into " +
                    "a crowd of undead warriors. You sustain some dents to your armor and manage to " +
                    "get a few hits in before you're forced to retreat.";
            }
            else if (playerClass == 1)
            {
                healthLost += 20;
                rDesc.text = "A mage shouldn't necessarily jump head first into battle, but you do " +
                    "anyway. It doesn't turn out well, since as soon as you try to cast your first spell " +
                    "an arrow from a skeletal archer grazes your skin and flee in pain.";
            }
            else if (playerClass == 2)
            {
                healthLost += 15;
                rDesc.text = "You make a valiant leap towards the crowd of skeletal warriors, but even " +
                    "your intricate dance of daggers is soon overwhelmed and you're forced to flee. You " +
                    "must be getting rusty with the footwork.";
            }
            else
            {
                Debug.Log("ERROR ERROR ERROR ERROR");
            }

            // LOAD FAILURE SCREEN
            rTitle.text = "The Undead live on!";
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
       dexModifier = -10; // FIXME: TESTING ONLY

        Debug.Log("Grave DC: " + diceRoll);

        diceRoll += dexModifier; // add dex modifier

        Debug.Log("Grave DC + Modifiers: " + diceRoll);

        if (diceRoll >= 5) {
            // LOAD FAILURE SCREEN
            moraleGained += -Random.Range(5, 16);
            rTitle.text = "You run away from your problems!";
            rDesc.text = "You run away from slaying the undead menace, but can't help feel an aura of " +
                "disappointment emanating from at least one of the villagers.";
            rGold.text = ((int)goldGained).ToString();
            rMorale.text = ((int)goldGained).ToString();
            rHealth.text = ((int)healthLost).ToString();
            resultCanvas.SetActive(true);
        }
        else 
        {
            moraleGained += -Random.Range(5, 16);
            healthLost += 5;
            rTitle.text = "You run away from your problems!";
            rDesc.text = "You run away from slaying the undead menace, but one of the skeletal archers " +
                "notices you and you feel the sharp tip of an arrow slightly graze your skin"; // sickness here?
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
