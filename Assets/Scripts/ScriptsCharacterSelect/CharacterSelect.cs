using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    // -- Menu Objects --
    [Header(("Menus"))]
    [SerializeField]
    protected GameObject CharacterSelectMenu;

    [SerializeField]
    protected GameObject CharacterCustomizationMenu;

    [SerializeField]
    protected GameObject VillagerNamingMenu;

    // -- Character Selection --
    [Header(("Character Select Events"))]
    
    [SerializeField]
    protected TMP_Text heroChoice;

    public void ShowHero()
    {
        switch (chosenHero)
        {
            case 0:
                heroChoice.text = "Knight";
                break;
            case 1:
                heroChoice.text = "Mage";
                break;
            case 2:
                heroChoice.text = "Rouge";
                break;
        }
    }

    [SerializeField]
    protected int chosenHero = 0;

    public void SelectNextHero()
    {
        chosenHero++;
        if (chosenHero > 2)
        {
            chosenHero = 0;
        }
        ShowHero();
    }

    public void SelectPreviousHero()
    {
        chosenHero--;
        if (chosenHero < 0)
        {
            chosenHero = 2;
        }
        ShowHero();
    }

    protected Hero hero;
    public void ChooseHero(int choice)
    {
        switch (choice)
        {
            case 0:
                hero = new Hero(0, 7, 5, 5);
                break;
            case 1:
                hero = new Hero(1, 5, 7, 5);
                break;
            case 2:
                hero = new Hero(2, 5, 5, 7);
                break;
        }
    }

    // -- Character Customization --
    [Header(("Character Customization Events"))]

    [SerializeField]
    protected TMP_InputField heroNameInput;

    [SerializeField]
    protected TMP_Text[] characterStats;
    
    public void ListStats()
    {
        characterStats[0].text = hero.Health.ToString();
        characterStats[1].text = hero.Strength.ToString();
        characterStats[2].text = hero.Mana.ToString();
        characterStats[3].text = hero.Luck.ToString();
    }
    
    void ChangeStats(int statIndex, int amount)
    {
        switch (statIndex)
        {
            case 0:
                hero.Health += amount;
                characterStats[statIndex].text = hero.Health.ToString();
                break;
            case 1:
                hero.Strength += amount;
                characterStats[statIndex].text = hero.Strength.ToString();
                break;
            case 2:
                hero.Mana += amount;
                characterStats[statIndex].text = hero.Mana.ToString();
                break;
            case 3:
                hero.Luck += amount;
                characterStats[statIndex].text = hero.Luck.ToString();
                break;
        }
    }

    public void IncreaseStats(int statIndex)
    {
        ChangeStats(statIndex, 1);
    }

    public void DecreaseStats(int statIndex)
    {
        ChangeStats(statIndex, -1);
    }


    [SerializeField]
    protected Slider moralitySlider;

    public void SlideByInterval(int interval)
    {
        int value = Mathf.RoundToInt(moralitySlider.value / interval) * interval;
        moralitySlider.value = value;
    }


    // -- Villager Name Select -- 
    [Header(("Villager Name Events"))]
    [SerializeField]
    protected TMP_InputField[] villagerNames;

    public void BeginJourney()
    {
        for (int i = 0; i < villagerNames.Length; i++)
        {
            PlayerPrefs.villagers[i] = new Person(villagerNames[i].text);
        }
        PlayerPrefs.hero = hero;
        SceneManager.LoadScene("Game");
    }

    // -- Menu functions --
    public void MakeSelection()
    {
        ChooseHero(chosenHero);
        CharacterSelectMenu.SetActive(false);
        CharacterCustomizationMenu.SetActive(true);
        heroNameInput.text = hero.Name;
        ListStats();
    }

    public void ConfirmCustomization()
    {
        hero.Name = heroNameInput.text;
        CharacterCustomizationMenu.SetActive(false);
        VillagerNamingMenu.SetActive(true);
    }

    void Start()
    {
        ShowHero();
    }
}
