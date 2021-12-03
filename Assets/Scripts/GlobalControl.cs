using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// UNUSED IN FAVOR OF PLAYER.PREFS
// Help from: https://www.sitepoint.com/saving-data-between-scenes-in-unity/

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    // Distace Time Data
    public float Distance;
    public float Time;

    public bool isGameOver = false;

    // Landmark Data [Don't worry about this]
    public bool l1Reached;
    public bool l2Reached;
    public bool l3Reached;
    public bool l4Reached;

    // Player Status Data
    public int Health;
    public int Food;        // if no food increase sickness
    public int Morale;      // if morale low decrease stats
    public int Clothing;    // clothes
    public int Aurum;       // currency
    public bool isSick;     // sickness

    // Party Status Data
    public bool villager1IsDead;
    public bool villager1IsSick;

    public bool villager2IsDead;
    public bool villager2IsSick;

    public bool villager3IsDead;
    public bool villager3IsSick;

    // Player Stats Data 
    public int Class;       // 0: knight, 1: mage, 2: rouge
    public int Int;
    public int Dex;
    public int Str;


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
        if (PlayerPrefs.hero.Health == 0 || PlayerPrefs.hero.Morale == 0)
        {
            //using the game over scene method 
            SceneManager.LoadScene("GameOver");
            isGameOver = true;
        }

    }
}
