using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from: https://www.youtube.com/watch?v=q1gAtOWTs-o
// Help from: https://www.youtube.com/watch?v=1h2yStilBWU
public class EventSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] events;
    int randomEvent;

    [SerializeField] private bool stopSpawn = false;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEvent", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void SpawnEvent()
    {
        // Begin very inefficient if-statements here:
        randomEvent = Random.Range(0, events.Length);
        Instantiate(events[randomEvent], transform.position, transform.rotation);
        if (stopSpawn)
        {
            CancelInvoke("SpawnEvent");
        }
    }
}
