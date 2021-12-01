using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestTransitions : MonoBehaviour
{
    public void returnToOverworld()
    {
        SceneManager.LoadScene("Overworld");
        Time.timeScale = 1f;
    }
    public void endGame()
    {
        SceneManager.LoadScene("Main Menu");
        GlobalControl.Instance.Distance = 0;
        GlobalControl.Instance.Time = 0;
        Time.timeScale = 0f;
    }
    public void goToSthopping()
    {
        SceneManager.LoadScene("Sthopping");
    }
}
