using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from: https://www.youtube.com/watch?v=4YQVrs46f6k
public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rb;
    private float width;
    private float scrollingSpeed = .10f;

    // Start is called before the first frame update
    // This is your init, kind of
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        width = boxCollider.size.x;
        boxCollider.enabled = false;
        rb.velocity = new Vector2(scrollingSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > width)
        {
            Vector2 resetPosition = new Vector2(-1 * width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
