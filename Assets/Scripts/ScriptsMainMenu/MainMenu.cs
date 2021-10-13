using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void VentureForth()
    {
        SceneManager.LoadScene("Character Select");
    }

    public void QuitGame()
    {
        Debug.Log("You Quit");
        Application.Quit();
    }
}
