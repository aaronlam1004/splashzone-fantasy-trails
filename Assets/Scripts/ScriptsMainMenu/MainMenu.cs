using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject HomeMenu;
    public GameObject AboutMenu;

    public void VentureForth()
    {
        SceneManager.LoadScene("Character Select");
    }

    public void QuitGame()
    {
        Debug.Log("You Quit");
        Application.Quit();
    }

    public void GoToAbout()
    {
        AboutMenu.SetActive(true);
        HomeMenu.SetActive(false);
    }

    public void GoToHome()
    {
        HomeMenu.SetActive(true);
        AboutMenu.SetActive(false);
    }
}
