using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RdBoulderManager : MonoBehaviour
{
    [SerializeField] private Text itemIncrease;
    private int moraleGained = 0; // MORALE PROPERTY

    // SAVE TO GLOBAL CONTROL
    public void SaveChanges()
    {
        PlayerPrefs.hero.Morale += moraleGained;
        if (PlayerPrefs.hero.Morale >= 100)
        {
            PlayerPrefs.hero.Morale = 100;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        moraleGained = Random.Range(15, 21);
        itemIncrease.text = "+" + moraleGained + " to Morale gained.";
        SaveChanges();
    }


}
