using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from: https://www.sitepoint.com/saving-data-between-scenes-in-unity/

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    // Distace Time Data
    public float Distance;
    public float Time;

    // Landmark Data
    public bool l1Reached;
    public bool l2Reached;
    public bool l3Reached;
    public bool l4Reached;

    // Player Data
    public int Food;
    public int Morale;


    // The Singleton Design Pattern (outdated apparently)
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
    }
}
