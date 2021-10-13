using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from: https://www.youtube.com/watch?v=U3sT-T5bKX4&list=WL&index=101

public class ScrollingParty : MonoBehaviour
{
    public float partySpeed;
    private Rigidbody2D rb;
    private Vector2 partyDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Party does not move (for now)
        partyDirection = new Vector2(0, 0);

    }

    // Called once per physics frame
    // Anything that happens to RigidBody2D should happen here
    void FixedUpdate()
    {
        // Party has no real velocity physics (for now)
        rb.velocity = new Vector2(0, partyDirection.y * partySpeed);
    }
}
