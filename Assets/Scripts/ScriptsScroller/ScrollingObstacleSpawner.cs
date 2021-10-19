using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from: https://www.youtube.com/watch?v=U3sT-T5bKX4&list=WL&index=102

public class ScrollingObstacleSpawner : MonoBehaviour
{
    // The obstacle in this case refers to the event
    public GameObject obstacle;
    public float minX;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    private bool exists = false;

// Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        if (exists == false)
        {
            Instantiate(obstacle, transform.position + new Vector3(minX, minY, 0), transform.rotation);
            exists = true;
        }
    }
}
