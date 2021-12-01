using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RdItemManager : MonoBehaviour
{
    [SerializeField] private Text itemTitle;
    [SerializeField] private Text itemIncrease;
    private int chance;
    private int chance2;

    private int foodGained = 0; // FOOD PROPERTY
    private int goldGained = 0; // GOLD PROPERTY
    private int intGained = 0; // INT PROPERTY
    private int dexGained = 0; // DEX PROPERTY
    private int strGained = 0; // STR PROPERTY

    // SAVE TO GLOBAL CONTROL
    public void SaveFoodGold()
    {
        GlobalControl.Instance.Food += foodGained;
        GlobalControl.Instance.Aurum += goldGained;
        Debug.Log("GlobalNewFood: " + GlobalControl.Instance.Food);
        Debug.Log("GlobalNewGold: " + GlobalControl.Instance.Aurum);
        PlayerPrefs.hero.Aurum += goldGained;
    }
    public void SaveStats()
    {
        GlobalControl.Instance.Int += intGained;
        GlobalControl.Instance.Dex += dexGained;
        GlobalControl.Instance.Str += strGained;
        Debug.Log("GlobalNewInt: " + GlobalControl.Instance.Int);
        Debug.Log("GlobalNewDex: " + GlobalControl.Instance.Dex);
        Debug.Log("GlobalNewStr: " + GlobalControl.Instance.Str);
        PlayerPrefs.hero.Intelligence += intGained;
        PlayerPrefs.hero.Dexterity += dexGained;
        PlayerPrefs.hero.Strength += strGained;
    }

    // Start is called before the first frame update
    void Start()
    {
        chance = Random.Range(1, 101);
        chance2 = Random.Range(1, 4);
        if (chance >= 1 && chance <= 20) // 20% for food, 1-20
        {
            foodGained += Random.Range(15, 21);
            itemTitle.text = "A hidden stash of food.";
            itemIncrease.text = foodGained + " units of Food gained.";
        }
        else if (chance >= 21 && chance <= 40) // 20% for gold, 21-40
        {
            goldGained += Random.Range(100, 151);
            itemTitle.text = "A concealed bag with some Aurum.";
            itemIncrease.text = goldGained + " pieces of Aurum gained.";
        }
        else if (chance >= 41 && chance <= 70) // 30% for nothing, 41-70
        {
            itemTitle.text = "Your search is fruitless.";
            itemIncrease.text = "You walk out empty handed.";
        }
        else if (chance >= 71 && chance <= 80) // 10% for int increase, 71-80
        {
            intGained += 1;
            if (chance2 == 1)
            {
                itemTitle.text = "A collector's edition dictionary.";
            }
            else if (chance2 == 2) {
                itemTitle.text = "A circlet of concentration.";
            }
            else
            {
                itemTitle.text = "A scroll of slightly forbidden knowledge.";
            }
            itemIncrease.text = "+" + intGained + " to INT gained.";
        }

        else if (chance >= 81 && chance <= 90) // 10% for dex increase, 81-90
        {
            dexGained += 1;
            if (chance2 == 1)
            {
                itemTitle.text = "A charm with a lightning symbol.";
            }
            else if (chance2 == 2)
            {
                itemTitle.text = "A ring infused with minor haste.";
            }
            else
            {
                itemTitle.text = "A rusty multitool.";
            }
            itemIncrease.text = "+" + dexGained + " to DEX gained.";
        }

        else // 10% for str increase, 91-100
        {
            strGained += 1;
            if (chance2 == 1)
            {
                itemTitle.text = "A bottle of strength enhancement pills.";
            }
            else if (chance2 == 2)
            {
                itemTitle.text = "Enchanted knitted mittens of minor strength.";
            }
            else
            {
                itemTitle.text = "A manual for aspiring pugilists.";
            }
            itemIncrease.text = "+" + strGained + " to STR gained.";
        }

        // SAVE TO GLOBAL CONTROL
        SaveFoodGold();
        SaveStats();
    }


}
