using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    // Text that is displayed on the main UI canvas
    [SerializeField] private Text distanceText;
    [SerializeField] private Text daysText;


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

            // ACCOUNT FOR DAYS (if distace is progressing)
            _days += 1;
            daysText.text = ((int)_days).ToString();
            
            // SAVE TO GLOBAL CONTROL
            SaveTimeDistance();
        }
    }
}
