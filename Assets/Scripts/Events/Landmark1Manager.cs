using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmark1Manager : MonoBehaviour
{
    // SAVE TO GLOBAL CONTROL
    public void SaveChanges()
    {
        GlobalControl.Instance.Food += 20;
        GlobalControl.Instance.Morale += 20;
        GlobalControl.Instance.Int += 1;
        Debug.Log("GlobalNewFood: " + GlobalControl.Instance.Food);
        Debug.Log("GlobalNewMorale: " + GlobalControl.Instance.Morale);
        Debug.Log("GlobalNewInt: " + GlobalControl.Instance.Int);

        PlayerPrefs.hero.Food += 20;
        PlayerPrefs.hero.Morale += 20;
        PlayerPrefs.hero.Intelligence += 1;

    }
    // Start is called before the first frame update
    void Start()
    {
        SaveChanges();
    }
}
