using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RdFoodManager : MonoBehaviour
{
    [SerializeField] private string foodType; // "Berries" or "Deer"
    [SerializeField] private GameObject resultCanvas;
    [SerializeField] private TextMeshProUGUI rTitle;
    [SerializeField] private TextMeshProUGUI rDesc;
    [SerializeField] private TextMeshProUGUI rFood;
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
    // private int strModifier;

    private bool success;

    private int playerClass; // 0: knight, 1: mage, 2: rouge

    private int _foodGained = 0; // FOOD PROPERTY
    public int FoodGained
    {
        get => _foodGained; // ACCESSOR
        set => _foodGained = value; // MUTATOR
    }
    private int _moraleGained = 0; // MORALE PROPERTY
    public int MoraleGained
    {
        get => _moraleGained; // ACCESSOR
        set => _moraleGained = value; // MUTATOR
    }

    // SAVE TO GLOBAL CONTROL
    public void SaveFood() 
    { 
        GlobalControl.Instance.Food += FoodGained;
        PlayerPrefs.hero.Food += FoodGained;
    }
    public void SaveMorale() 
    {
        GlobalControl.Instance.Morale += MoraleGained;
        if (GlobalControl.Instance.Morale < 0) 
        {
            GlobalControl.Instance.Morale = 0; 
        }
        PlayerPrefs.hero.Morale += MoraleGained;
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

        // BERRIES EVENT
        if (foodType == "Berries")
        {
            diceRoll = Random.Range(1, 21); // Roll a d20
            Debug.Log("Berries DC: " + diceRoll);

            diceRoll += intModifier; // add int modifier
            Debug.Log("Berries DC + Modifiers: " + diceRoll);

            if (diceRoll >= 10)
            {
                success = true;
            }
            else
            {
                success = false;
            }
        }
        // DEER EVENT
        else if (foodType == "Deer")
        {
            diceRoll = Random.Range(1, 21); // Roll a d20
            Debug.Log("Deer DC: " + diceRoll);
        }
        else
        {
            Debug.Log("ERROR ERROR ERROR ERROR");
        }
    }

    public void GatherBerries()
    {
        if (success)
        {
            FoodGained += Random.Range(15, 21);
            MoraleGained += Random.Range(10, 16);
            Debug.Log("Food Gained: " + FoodGained);
            Debug.Log("Morale Gained: " + MoraleGained);

            // LOAD SUCCESS SCREEN
            rTitle.text = "Edibility Identified!";
            rDesc.text = "You tested the food and found it was safe! You take the " +
                "extra food and put it in your storage. " +
                "The fruits of your brain-labor pay off as you take each mouthwatering bite.";
            rFood.text = ((int)FoodGained).ToString();
            rMorale.text = ((int)MoraleGained).ToString();
            resultCanvas.SetActive(true);

            // LOAD TO GLOBAL CONTROL
            SaveFood();
            SaveMorale();
        }
        else
        {
            MoraleGained -= Random.Range(10, 16);
            Debug.Log("Morale Lost: " + MoraleGained);

            // LOAD FAILURE SCREEN
            rTitle.text = "A Sad Mistake";
            rDesc.text = "Haven't your parents ever taught you not to eat anything you see? " +
                "The fruit was rotten and extremely bitter, leaving you coughing " +
                "and gagging in a disappointed fit.";
            rFood.text = ((int)FoodGained).ToString();
            rMorale.text = ((int)MoraleGained).ToString();
            resultCanvas.SetActive(true);

            // LOAD TO GLOBAL CONTROL
            SaveFood();
            SaveMorale();
        }
    }

    public void DirectHuntDeer() // Harder Dex Check, More Morale, More Food
    {
        diceRoll += dexModifier; // add dex modifier
        Debug.Log("Deer DC + Modifiers: " + diceRoll);
        if (diceRoll >= 20) { success = true; }
        else { success = false; }

        if (success) // SUCCESS
        {
            FoodGained += Random.Range(30, 36);
            MoraleGained += Random.Range(15, 21);

            // Class flavor text - 0: knight, 1: mage, 2: rouge
            if (playerClass == 0)
            {
                rDesc.text = "In a sudden rush of adrenaline you throw your sword at the herd with " +
                    "all of your might. Your spinning metal death stick decapitates two deer before " +
                    "it lodges itself in a tree. You pay your respects.";
            }
            else if (playerClass == 1)
            {
                rDesc.text = "You cast the most successful fireball of your life, at a herd of helpless " +
                    "animals no less. Regardless you pay your respects to the cooked--I mean " +
                    "charred--remains of your prey.";
            }
            else if (playerClass == 2)
            {
                rDesc.text = "You fly forward at the speed of sound and engage in a dance of daggers, " +
                    "slicing and dicing all around you. When you open your eyes the remains of two deer " +
                    "are at your feet. You pay your respects.";
            }
            else
            {
                Debug.Log("ERROR ERROR ERROR ERROR");
            }

            // LOAD SUCCESS SCREEN
            rTitle.text = "Meat's Back on the Menu!";
            rFood.text = ((int)FoodGained).ToString();
            rMorale.text = ((int)MoraleGained).ToString();
            resultCanvas.SetActive(true);

            // LOAD TO GLOBAL CONTROL
            SaveFood();
            SaveMorale();
        }
        else // FAILURE
        {
            MoraleGained -= Random.Range(10, 21);
            Debug.Log("Morale Lost: " + MoraleGained);

            // Class flavor text - 0: knight, 1: mage, 2: rouge
            if (playerClass == 0)
            {
                rDesc.text = "You charge at the deer, but a knight in shining armor can't exactly " +
                    "keep up with animals built for running away. You feel a little embarassed.";
            }
            else if (playerClass == 1)
            {
                rDesc.text = "You cast a fireball at a helpless crowd of deer, but miss and set some nearby " +
                    "saplings aflame. Needless to say, the deer escape.";
            }
            else if (playerClass == 2)
            {
                rDesc.text = "Against your better judgement you rush towards the herd of deer. A valiant " +
                    "effort but people aren't exactly as fast as animals built for escape.";
            }
            else
            {
                Debug.Log("ERROR ERROR ERROR ERROR");
            }

            // LOAD FAILURE SCREEN
            rTitle.text = "A Great Escape";
            rFood.text = ((int)FoodGained).ToString();
            rMorale.text = ((int)MoraleGained).ToString();
            resultCanvas.SetActive(true);

            // LOAD TO GLOBAL CONTROL
            SaveFood();
            SaveMorale();
        }
    }

    public void SneakyHuntDeer() // Easier dex check, Less Morale, Less Food
    {
        diceRoll += dexModifier; // add dex modifier
        Debug.Log("Deer DC + Modifiers: " + diceRoll);
        if (diceRoll >= 15) { success = true; }
        else { success = false; }

        if (success) // SUCCESS
        {
            FoodGained += Random.Range(26, 31);
            MoraleGained += Random.Range(15, 21);

            // Class flavor text - 0: knight, 1: mage, 2: rouge
            if (playerClass == 0)
            {
                rDesc.text = "You snap a long branch off a tree and use your sword to carve a spear. " +
                    "You approach the deer in your rickety metal armor, but by the gods, they " +
                    "do not notice you before you manage to slay one. You pay your respects.";
            }
            else if (playerClass == 1)
            {
                rDesc.text = "You sneak up on the deer, and by the gods, they do not notice your approach. " +
                    "You cast the sneakiest fireball, or firebolt in this case, to slay one of the deer before " +
                    "the others make their escape.";
            }
            else if (playerClass == 2)
            {
                rDesc.text = "You hastefully but gracefully make your way towards the herd. You " +
                    "manage to slay one of the deer with a well-placed throwing knife to the throat.";
            }
            else
            {
                Debug.Log("ERROR ERROR ERROR ERROR");
            }

            // LOAD SUCCESS SCREEN
            rTitle.text = "Meat's Back on the Menu!";
            rFood.text = ((int)FoodGained).ToString();
            rMorale.text = ((int)MoraleGained).ToString();
            resultCanvas.SetActive(true);

            // LOAD TO GLOBAL CONTROL
            SaveFood();
            SaveMorale();
        }
        else // FAILURE
        {
            MoraleGained -= Random.Range(10, 21);
            Debug.Log("Morale Lost: " + MoraleGained);

            // Class flavor text - 0: knight, 1: mage, 2: rouge
            if (playerClass == 0)
            {
                rDesc.text = "A knight in shining armor can try to sneak around, but they are still in " +
                    "shining armor. Unsurprisingly the deer notice your rickety getup. You feel a " +
                    "little embarassed.";
            }
            else if (playerClass == 1)
            {
                rDesc.text = "You try to sneak closer to the deer, but accidentally snap a twig to which" +
                    "all of the deer turn their heads toward you. They run away, leaving your spells uncast " +
                    "and stomach grumbling.";
            }
            else if (playerClass == 2)
            {
                rDesc.text = "You try to sneak ever closer and closer to the herd of deer, but for whatever " +
                    "culmination of reasons you fail. You failed at sneaking for a rogue and the deer " +
                    "run away.";
            }
            else
            {
                Debug.Log("ERROR ERROR ERROR ERROR");
            }

            // LOAD FAILURE SCREEN
            rTitle.text = "A Great Escape";
            rFood.text = ((int)FoodGained).ToString();
            rMorale.text = ((int)MoraleGained).ToString();
            resultCanvas.SetActive(true);

            // LOAD TO GLOBAL CONTROL
            SaveFood();
            SaveMorale();
        }
    }


    public void AdmireDeer() // More Morale, No Food
    {
        MoraleGained += Random.Range(10, 16);

        // LOAD ADMIRE SCREEN
        rTitle.text = "A Melancholic Sight";
        rDesc.text = "You stop to stare at the deer from a distance. You can't help but " +
            "feel that you and your party are much like the prey in front of you. Still, you " +
            "begin to swell with the courage to protect your charges.";
        rFood.text = ((int)FoodGained).ToString();
        rMorale.text = ((int)MoraleGained).ToString();
        resultCanvas.SetActive(true);

        // LOAD TO GLOBAL CONTROL
        SaveFood();
        SaveMorale();
    }


}
