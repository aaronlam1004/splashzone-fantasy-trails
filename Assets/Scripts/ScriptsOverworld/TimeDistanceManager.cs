using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Help from: https://www.youtube.com/watch?v=U3sT-T5bKX4

public class TimeDistanceManager : MonoBehaviour
{
    // Distance is used by other scripts
    // Days is used by other scripts
    // Underscore is used when defining the private member variable for a public property
    private float _distance; // FIELD
    private float _days; // FIELD
    // Accessors & Mutators w/ Properties:
    public float Distance // PROPERTY
    {
        get => _distance; // ACCESSOR
        set => _distance = value; // MUTATOR
    }
    public float Days // PROPERTY
    {
        get => _days; // ACCESSOR
        set => _days = value; // MUTATOR
    }


    // SAVE TO GLOBAL OBJECT
    public void SaveTimeDistance()
    {
        GlobalControl.Instance.Distance = Distance;
        GlobalControl.Instance.Time = Days;
    }

    // UPDATE HEALTH AND MORALE OVER TIME
    public void UpdateHealthMoraleFood()
    {
        if (PlayerPrefs.hero.Health < 100)
        {
            PlayerPrefs.hero.Health += 1;
        }
        PlayerPrefs.hero.Morale -= Random.Range(0, 3);
        if (PlayerPrefs.hero.Food > 0)
        {
            PlayerPrefs.hero.Food -= 3; // LOSE 1 FOOD PER 2 IN THE PARTY
            if (PlayerPrefs.hero.Food <= 0) // TRIGGER HUNGER
            {
                PlayerPrefs.hero.Food = 0;
            }
        }
        PlayerPrefs.hero.Morale -= Random.Range(0, 3);
    }


    // Text that is displayed on the main UI canvas
    [SerializeField] private Text distanceText;
    [SerializeField] private Text daysText;
    [SerializeField] private Text heroText;


    // Default should be 4 & 6 and CHECK THE EDITOR TOO
    // Progress by 1 day every 6 seconds and calculate distance traveled
    // The longer the days take to progres, the more events you will encounter
    [SerializeField] private float timeDistanceStart = 0;
    [SerializeField] private float timeDistanceDelay = 6;
    private int _randomNormalDistance;


    // Start InvokeRepeating, according to timeDistanceDelay
    void Start()
    {
        // LOAD FROM GLOBAL CONTROL
        Distance = GlobalControl.Instance.Distance;
        Days = GlobalControl.Instance.Time;
        InvokeRepeating("AddTimeDistance", timeDistanceStart, timeDistanceDelay);
    }

    void AddTimeDistance()
    {

        // Average human can march about 8 miles a day at a minimum
        _randomNormalDistance = Random.Range(8, 14);
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            // ACCOUNT FOR DISTANCE (if distace is progressing)
            _distance += _randomNormalDistance;
            distanceText.text = ((int)_distance).ToString() + " mi";
            PlayerPrefs.hero.Distance = ((int)_distance).ToString() + " mi";

            heroText.text = $"<b><i>{PlayerPrefs.hero.Name}</i></b>\n" +
                           $"Health: <color=#FF0000>{PlayerPrefs.hero.Health}</color>\n" +
                           $"Morale: <color=#DBAC00>{PlayerPrefs.hero.Morale}</color>\n" +
                           $"Aurums: <color=#DBAC00>{PlayerPrefs.hero.Aurum}</color>\n" +
                           $"Food: <color=#DBAC00>{PlayerPrefs.hero.Food}</color>\n" +
                           $"Clothes: <color=#797EF6>{PlayerPrefs.hero.Clothes}</color>\n" +
                           $"Strength: {PlayerPrefs.hero.Strength}\n" + 
                           $"Dexterity: {PlayerPrefs.hero.Dexterity}\n" + 
                           $"Intelligence: {PlayerPrefs.hero.Intelligence}\n";

            // ACCOUNT FOR DAYS (if distace is progressing)
            _days += 1;
            daysText.text = ((int)_days).ToString();

            // SAVE TO GLOBAL CONTROL
            UpdateHealthMoraleFood();
            SaveTimeDistance();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
            GlobalControl.Instance.Distance = 0;
            GlobalControl.Instance.Time = 0;
            Time.timeScale = 0f;
        }
    }
}
