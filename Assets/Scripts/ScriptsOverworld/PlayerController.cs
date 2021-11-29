using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from: https://www.youtube.com/watch?v=4YQVrs46f6k
public class PlayerController : MonoBehaviour
{
    // Initialize BoxCollider2D and Rigidbody2D
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    // Need to account for whether the player should be moving
    private bool _playerIsMoving = true;
    public bool PlayerIsMoving
    {
        get => _playerIsMoving; // ACCESSOR
        set => _playerIsMoving = value; // MUTATOR
    }

    // Account for whether an event is triggered
    private bool _eventIsTriggered = false;
    public bool EventIsTriggered
    {
        get => _eventIsTriggered; // ACCESSOR
        set => _eventIsTriggered = value; // MUTATOR
    }

    // Account for what type of event is triggered
    private int _eventTypeTriggered;
    public int EventTypeTriggered
    {
        get => _eventTypeTriggered; // ACCESSOR
        set => _eventTypeTriggered = value; // MUTATOR
    }

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
}
