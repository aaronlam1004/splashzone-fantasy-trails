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
    public static int chosenHero = 0;

    public void SelectNextHero()
    {
        chosenHero++;
        if (chosenHero > 2)
        {
            chosenHero = 0;
        }
        ChooseHero(chosenHero);
        ShowHero();
        ListStats();
        ShowDescription();
    }

    public void SelectPreviousHero()
    {
        chosenHero--;
        if (chosenHero < 0)
        {
            chosenHero = 2;
        }
        ChooseHero(chosenHero);
        ShowHero();
        ListStats();
        ShowDescription();
    }

    protected Hero hero;
    public void ChooseHero(int choice)
    {
        switch (choice)
        {
            case 0:
                hero = new Hero(0);
                break;
            case 1:
                hero = new Hero(1);
                break;
            case 2:
                hero = new Hero(2);
                break;
        }
    }

    [SerializeField]
    protected TMP_InputField heroNameInput;

    [SerializeField]
    protected TMP_Text[] characterStats;
    
    public void ListStats()
    {
        characterStats[0].text = $"Strength: <color=#AD0000><size=90>{hero.Strength.ToString()}</size></color>";
        characterStats[1].text = $"Dexterity: <color=#AD0000><size=90>{hero.Dexterity.ToString()}</size></color>";
        characterStats[2].text = $"Intelligence: <color=#AD0000><size=90>{hero.Intelligence.ToString()}</size></color>";
    }

    [SerializeField]
    protected TMP_Text characterDescription;
    public void ShowDescription()
    {
        characterDescription.text = hero.Description;
    }

    // -- Villager Name Select -- 
    [Header(("Villager Name Events"))]
    [SerializeField]
    protected TMP_InputField[] villagerNames;

    // -- Menu functions --
    public void MakeSelection()
    {
        CharacterSelectMenu.SetActive(false);
        VillagerNamingMenu.SetActive(true);
    }
    
    public void GoBack()
    {
        CharacterSelectMenu.SetActive(true);
        VillagerNamingMenu.SetActive(false);
    }

    public void BeginJourney()
    {
        for (int i = 0; i < villagerNames.Length; i++)
        {
            PlayerPrefs.villagers[i] = new Person(villagerNames[i].text);
        }
        hero.Name = heroNameInput.text;
        PlayerPrefs.hero = hero;
        SceneManager.LoadScene("Sthopping");
    }

    void Start()
    {
        ChooseHero(chosenHero);
        ShowHero();
        ListStats();
        ShowDescription();
    }
}
