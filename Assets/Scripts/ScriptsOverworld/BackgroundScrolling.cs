using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from: https://www.youtube.com/watch?v=4YQVrs46f6k
public class BackgroundScrolling : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private Vector2 velocity;
    [SerializeField] private float width; // WIDTH SHOULD BE 24
    [SerializeField] private float scrollingSpeed;

    // Start is called before the first frame update
    // This is your init, kind of
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider.enabled = false;
        velocity = new Vector2(scrollingSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity;
        if (transform.position.x > width) // where width is supposed to go
        {
            Vector2 resetPosition = new Vector2(-1 * width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
