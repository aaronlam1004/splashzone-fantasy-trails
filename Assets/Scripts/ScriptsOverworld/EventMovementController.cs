using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMovementController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rb;

    // Given how events will always move to the right on a fixed x, y and z axis,
    // only the line below is needed to determine movement speed going right.
    private float movementSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(movementSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
