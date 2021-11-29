using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Help from: https://www.youtube.com/watch?v=4YQVrs46f6k
public class EventTrigger : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    // Where to direct players
    [SerializeField] private string sceneToLoad;

    // Event types
    private int _eventType;

    public int EventType
    {
        get => _eventType; // ACCESSOR
    }

    // Given how events will always move to the right on a fixed x, y and z axis,
    // only the line below is needed to determine movement speed going right.
    private float movementSpeed = 2.75f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(movementSpeed, 0);
    }


    // If player encounter's an event, transfer player to event screen
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene(sceneToLoad);
            Destroy(gameObject);
        }
    }
}
