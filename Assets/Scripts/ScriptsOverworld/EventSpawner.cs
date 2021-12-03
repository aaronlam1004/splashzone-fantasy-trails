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

        // Spawn an event around every 5 seconds
        spawnTime = Random.Range(5, 6);
        spawnDelay = Random.Range(5, 6);
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
        if (tdm.Distance >= 181f - 32f && tdm.Distance < 181f + 16f) { }
        else if (tdm.Distance >= 362f - 32f && tdm.Distance < 362f + 16f) { }
        else if (tdm.Distance >= 543f - 32f && tdm.Distance < 543f + 16f) { }
        else if (tdm.Distance >= 724f - 32f && tdm.Distance < 724f + 128f) { }

        // Else Generate Random Events (sprite indexes 4-15, 11 total)
        else
        {
            // BEGING IF STATEMENTS HERE (FIXME: error when near landmark)
            chance = Random.Range(1, 101);
            if (chance >= 1 && chance <= 15) // 15% chance for berries, 1-15
            {
                // 1. Berries (Food)
                Instantiate(eventTriggers[4], transform.position, transform.rotation);
            }
            else if (chance >= 16 && chance <= 30) // 15% chance for deer, 16-30
            {
                // 2. Deer (Food)
                Instantiate(eventTriggers[5], transform.position, transform.rotation);
            }
            else if (chance >= 31 && chance <= 45) // 15% chance for house, 31-45
            {
                // 3. House (Item)
                Instantiate(eventTriggers[6], transform.position, transform.rotation);
            }
            else if (chance >= 46 && chance <= 55) // 10% chance for blizzard, 46-55
            {
                // 4. Blizzard (Stat Check)
                Instantiate(eventTriggers[7], transform.position, transform.rotation);
            }
            else if (chance >= 56 && chance <= 70) // 15% chance for wolves, 56-70
            {
                // 5. Wolves (Stat Check)
                Instantiate(eventTriggers[8], transform.position, transform.rotation);
            }
            else if (chance >= 71 && chance <= 80) // 10% chance for graveyard, 71-80
            {
                // 6. Graveyard (Combat)
                Instantiate(eventTriggers[9], transform.position, transform.rotation);
            }
            else if (chance >= 81 && chance < 95) // 15% chance for slime, 81-95
            {
                // 7. Slime (Combat)
                Instantiate(eventTriggers[10], transform.position, transform.rotation);
            }
            else  // 8. Boulder (FIXME: Joke) // 5% chance for boulder, 96-100
            {
                Instantiate(eventTriggers[11], transform.position, transform.rotation);
            }
        }

        if (stopSpawn)
        {
            CancelInvoke("SpawnEvent");
        }
    }
}
