using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from: https://www.youtube.com/watch?v=4YQVrs46f6k
public class PlayerController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, moveSpeed);
    }
}
