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
        GlobalControl.Instance.Morale += moraleGained;
        Debug.Log("GlobalNewMorale: " + GlobalControl.Instance.Morale);
    }

    // Start is called before the first frame update
    void Start()
    {
        moraleGained = Random.Range(10, 21);
        itemIncrease.text = "+" + moraleGained + " to Morale gained.";

        // SAVE TO GLOBAL CONTROL
        SaveChanges();
    }


}
