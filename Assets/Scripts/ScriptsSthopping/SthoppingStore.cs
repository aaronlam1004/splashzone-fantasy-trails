using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SthoppingStore : MonoBehaviour
{
    protected Button SelectedButton = null;
    protected Item SelectedItem = null;
    protected int SelectedIndex = -1;

    public GameObject Purchasing;
    protected int Cost = 0;
    protected int PurchasingAmount = 1;

    public void SetIndex(int index)
    {
        SelectedIndex = index;
    }

    public void SetItem(int index=-1)
    {
        if (index == -1)
        {
            SelectedItem = null;
        }
        else
        {
            SelectedItem = Items.items[index];
        }
    }

    public void HandleClicked(Button button)
    {
        if (SelectedButton != null)
        {
            SelectedButton.GetComponent<Outline>().enabled = false;
        }

        if (SelectedButton == button)
        {
            SelectedButton = null;

            SetIndex(-1);
            SetItem();

            Cost = 0;
            Purchasing.SetActive(false);

            ShowValues();
            ShowAmountPurchased();
        }
        else
        {
            SelectedButton = button;
            SelectedButton.GetComponent<Outline>().enabled = true;

            SetItem(SelectedIndex);

            PurchasingAmount = 1;
            Cost = SelectedItem.Price * PurchasingAmount;
            Purchasing.SetActive(true);

            ShowValues();
            ShowAmountPurchased();
        }
    }

    [Header(("Profiles"))]
    public TMP_Text HeroProfile;
    public TMP_Text HeroGold;
    public void ShowHeroProfile()
    {
        HeroProfile.text = $"<b><i>{PlayerPrefs.hero.Name}</i></b> "+
                           $"[<color=#FF0000>{PlayerPrefs.hero.Health}</color>/" +
                           $"<color=#DBAC00>{PlayerPrefs.hero.Morale}</color>]\n" +
                           $"<u>Strength:</u> {PlayerPrefs.hero.Strength}\n" + 
                           $"<u>Dexterity:</u> {PlayerPrefs.hero.Dexterity}\n" + 
                           $"<u>Intelligence:</u> {PlayerPrefs.hero.Intelligence}\n";
        
        HeroGold.text = $"<b>Aurum:</b> {PlayerPrefs.hero.Aurum}";
    }

    public TMP_Text[] VillagerProfiles;
    public void ShowVillagerProfiles()
    {
        for (var i = 0; i < 4; i++)
        {
            Person villager = PlayerPrefs.villagers[i];
            VillagerProfiles[i].text = $"<b><i>{villager.Name}</i></b>" +
                                       $"[<color=#FF0000>{villager.Health}</color>/" +
                                       $"<color=#DBAC00>{villager.Morale}</color>]";
        }
    }

    public TMP_Text DistanceProfile;
    public void ShowDistanceTraveled()
    {
        DistanceProfile.text = $"<u>Distance:</u> {PlayerPrefs.hero.Distance}";
    }

    public TMP_Text flavorText;
    public void ShowValues()
    {
        if (SelectedItem != null)
        {
            flavorText.text = $"<b><u>{SelectedItem.Name}</u></b>\n\n" +
                              $"{SelectedItem.FlavorText}";
        }
        else
        {
            flavorText.text = "";
        }
    }

    public TMP_Text PurchasingAmountText;
    public TMP_Text CostText;

    public void ShowAmountPurchased()
    {
        PurchasingAmountText.text = PurchasingAmount.ToString();
        CostText.text = $"Cost: {Cost.ToString()}";
        if (Cost > 0)
        {
            HeroGold.text = $"<b>Aurum:</b> {PlayerPrefs.hero.Aurum} <color=#FF5555>- {Cost}</color> = {PlayerPrefs.hero.Aurum - Cost}";
        }
        else
        {
            HeroGold.text = $"<b>Aurum:</b> {PlayerPrefs.hero.Aurum}";
        }
    }

    public void IncreaseAmount()
    {
        PurchasingAmount += 1;
        Cost = SelectedItem.Price * PurchasingAmount;
        ShowAmountPurchased();
    }

    public void DecreaseAmount()
    {
        if (PurchasingAmount > 1)
        {
            PurchasingAmount -= 1;
            Cost = SelectedItem.Price * PurchasingAmount;
            ShowAmountPurchased();
        }
    }

    [Header(("Inventory"))]
    public TMP_Text Inventory;
    public GameObject InventoryUsage;
    public TMP_Dropdown InventoryOptions;
    public void UpdateInventory()
    {
        List<Item> itemKeys = new List<Item>(PlayerPrefs.hero.Items.Keys);
        List<string> itemNames = new List<string>();
        int n = itemKeys.Count;
        if (n > 0)
        {
            InventoryUsage.SetActive(true);
            InventoryOptions.ClearOptions();

            Inventory.text = "";
            for (int i = 0; i < n; i++)
            {
                Item item = itemKeys[i];
                Inventory.text += $"- {item.Name} [{PlayerPrefs.hero.Items[item]}]\n";
                itemNames.Add(item.Name);
            }
            InventoryOptions.AddOptions(itemNames);
        }
        else
        {
            Inventory.text = "";
            InventoryUsage.SetActive(false);
        }
    }

    public void UseItem()
    {
        Item item = Items.getItemByName(InventoryOptions.captionText.text);
        PlayerPrefs.hero.UseItem(item);
        UpdateStats(item);
        UpdateInventory();
    }

    void UpdateStats(Item item)
    {
        switch (item.Category)
        {
            case 0:
                PlayerPrefs.hero.Strength += item.Boost;
                break;
            case 1:
                PlayerPrefs.hero.Dexterity += item.Boost;
                break;
            case 2:
                PlayerPrefs.hero.Intelligence += item.Boost;
                break;
            case 3:
                PlayerPrefs.hero.Morale += item.Boost;
                break;
            case 4:
                PlayerPrefs.hero.Health += item.Boost;
                break;
            case 5:
                PlayerPrefs.hero.Clothes += item.Boost;
                break;
            default:
                break;
        }
        ShowHeroProfile();
        ShowVillagerProfiles();
    }

    public void Purchase()
    {
        if (PlayerPrefs.hero.Aurum - Cost >= 0)
        {
            PlayerPrefs.hero.Aurum -= Cost;
            PlayerPrefs.hero.AddItem(SelectedItem, PurchasingAmount);

            SelectedButton.GetComponent<Outline>().enabled = false;
            SelectedButton = null;

            SetIndex(-1);
            SetItem();

            Cost = 0;
            Purchasing.SetActive(false);

            ShowValues();
            ShowAmountPurchased();
            UpdateInventory();
        }
    }

    void Start()
    {
        ShowValues();
        ShowAmountPurchased();
        ShowHeroProfile();
        ShowVillagerProfiles();
        UpdateInventory();
        ShowDistanceTraveled();
    }
}
