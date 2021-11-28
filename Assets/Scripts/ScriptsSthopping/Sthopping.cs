using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sthopping : MonoBehaviour
{
    public void VentureOff()
    {
        SceneManager.LoadScene("Overworld");
    }

    [Header(("Menus"))]
    [SerializeField]
    protected GameObject HomeMenu;

    [SerializeField]
    protected GameObject ShoppingMenu;
    
    [SerializeField]
    protected GameObject InventoryMenu;

    [SerializeField]
    public void ShowShopping()
    {
        HomeMenu.SetActive(false);
        ShoppingMenu.SetActive(true);
    }

    public void GoHome()
    {
        HomeMenu.SetActive(true);
        ShoppingMenu.SetActive(false);
        InventoryMenu.SetActive(false);
    }

    public void GoInventory()
    {
        InventoryMenu.SetActive(true);
        HomeMenu.SetActive(false);
    }
}
