using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from: https://www.youtube.com/watch?v=q1gAtOWTs-o
// Help from: https://www.youtube.com/watch?v=1h2yStilBWU
// References TimeDistanceManager
// Should be X: -20 & Y: -3 for Transform
public class EventSpawner : MonoBehaviour
{
    [SerializeField] private TimeDistanceManager tdm;
    [SerializeField] private GameObject[] eventTriggers;

    [SerializeField] private bool stopSpawn = false;
    private float spawnTime; // default should be 3
    private float spawnDelay;

    private bool landmark1Reached = false;
    private bool landmark2Reached = false;
    private bool landmark3Reached = false;
    private bool landmark4Reached = false;

    // Event types
    private int chance;
    private int _eventType;
    public int EventType
    {
        get => _eventType; // ACCESSOR
    }

    // SAVE TO GLOBAL CONTROL
    public void SaveLandmarkStatus()
    {
        GlobalControl.Instance.l1Reached = landmark1Reached;
        GlobalControl.Instance.l2Reached = landmark2Reached;
        GlobalControl.Instance.l3Reached = landmark3Reached;
        GlobalControl.Instance.l4Reached = landmark4Reached;
    }

    // Start is called before the first frame update
    void Start()
    {
        // LOAD FROM GLOBAL CONTROL
        landmark1Reached = GlobalControl.Instance.l1Reached;
        landmark2Reached = GlobalControl.Instance.l2Reached;
        landmark3Reached = GlobalControl.Instance.l3Reached;
        landmark4Reached = GlobalControl.Instance.l4Reached;

        // Spawn an event around every 5-8 seconds
        spawnTime = Random.Range(5, 9);
        spawnDelay = Random.Range(5, 9);
        InvokeRepeating("SpawnEvent", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate Landmark Generation (sprite indexes 0-3)
        if (tdm.Distance >= 181f && landmark1Reached == false)
        {
            landmark1Reached = true;
            SaveLandmarkStatus();
            Instantiate(eventTriggers[0], transform.position, transform.rotation);
        }
        else if (tdm.Distance >= 362f && landmark2Reached == false)
        {
            landmark2Reached = true;
            SaveLandmarkStatus();
            Instantiate(eventTriggers[1], transform.position, transform.rotation);
        }
        else if (tdm.Distance >= 543f && landmark3Reached == false)
        {
            landmark3Reached = true;
            SaveLandmarkStatus();
            Instantiate(eventTriggers[2], transform.position, transform.rotation);
        }
        else if (tdm.Distance >= 724f && landmark4Reached == false)
        {
            landmark4Reached = true;
            SaveLandmarkStatus();
            Instantiate(eventTriggers[3], transform.position, transform.rotation);
        }
    }

    // Handle Event Spawning Below
    void SpawnEvent()
    {
        // Guarantee Event doesn't spawn on Landmark
        if (tdm.Distance >= 181f - 32f && tdm.Distance < 181f + 8f) { }
        else if (tdm.Distance >= 362f - 32f && tdm.Distance < 362f + 8f) { }
        else if (tdm.Distance >= 543f - 32f && tdm.Distance < 543f + 8f) { }
        else if (tdm.Distance >= 724f - 32f && tdm.Distance < 724f + 128f) { }

        // Else Generate Random Events (sprite indexes 4-15, 11 total)
        else
        {
            // BEGING IF STATEMENTS HERE (FIXME: error when near landmark)
            chance = Random.Range(1, 101);
            if (chance >= 1 && chance <= 10) // 10% chance for berries, 1-10
            {
                // 0. Berries (Food)
                _eventType = 0;
                Instantiate(eventTriggers[4], transform.position, transform.rotation);
            }
            else if (chance >= 11 && chance <= 15) // 5% chance for deer, 11-15
            {
                // 1. Deer (Food)
                _eventType = 1;
                Instantiate(eventTriggers[5], transform.position, transform.rotation);
            }
            else if (chance >= 16 && chance <= 25) // 10% chance for item, 16-25
            {
                // 2. Present Box (Item)
                _eventType = 2;
                Instantiate(eventTriggers[6], transform.position, transform.rotation);
            }
            else if (chance >= 26 && chance <= 35) // 10% chance for river, 26-35
            {
                // 3. River (Stat Check)
                _eventType = 3;
                Instantiate(eventTriggers[7], transform.position, transform.rotation);
            }
            else if (chance >= 36 && chance <= 45) // 10% chance for boulder, 36-45
            {
                // 4. Boulder (Stat Check)
                _eventType = 4;
                Instantiate(eventTriggers[8], transform.position, transform.rotation);
            }
            else if (chance >= 46 && chance <= 60) // 15% chance for house, 46-60
            {
                // 5. House (Stat Check)
                _eventType = 5;
                Instantiate(eventTriggers[9], transform.position, transform.rotation);
            }
            else if (chance >= 61 && chance <= 70) // 10% chance for graveyard, 61-70
            {
                // 6. Graveyard (Combat)
                _eventType = 6;
                Instantiate(eventTriggers[10], transform.position, transform.rotation);
            }
            else if (chance >= 71 && chance < 80) // 10% chance for slime, 71-80
            {
                // 7. Slime (Combat)
                _eventType = 7;
                Instantiate(eventTriggers[11], transform.position, transform.rotation);
            }
            else if (chance >= 81 && chance < 90) // 10% chance for scouts, 81-90
            {
                // 8. Skeleton Scouts (Combat)
                _eventType = 8;
                Instantiate(eventTriggers[12], transform.position, transform.rotation);
            }
            else if (chance >= 91 && chance < 95) // 5% chance for friendly villagers, 91-95
            {
                // 9. Villagers w/ Shop Basket (Dialogue)
                _eventType = 9;
                Instantiate(eventTriggers[13], transform.position, transform.rotation);
            }
            else // 10. 5% chance for travelling merchant, 96-100
            {
                // Merchant w/ Coin (Dialogue)
                _eventType = 10;
                Instantiate(eventTriggers[14], transform.position, transform.rotation);
            }
        }

        if (stopSpawn)
        {
            CancelInvoke("SpawnEvent");
        }
    }
}
