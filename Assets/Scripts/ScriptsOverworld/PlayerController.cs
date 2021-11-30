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

    public Sprite[] Sprites;
    public SpriteRenderer CharacterSprite;
    public GameObject[] VillagerSprites;

    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        switch (PlayerPrefs.hero.HeroType)
        {
            case 0:
                index = 0;
                CharacterSprite.sprite = Sprites[index];
                break;
            case 1:
                index = 2;
                CharacterSprite.sprite = Sprites[index];
                break;
            default:
                index = 4;
                CharacterSprite.sprite = Sprites[index];
                break;
        }
    }

    float timer = 50;
    void Update()
    {
        if (timer > 0)
        {
            timer -= 1;
        }

        if (timer == 0)
        {
            index++;
            if (index % 2 == 0)
            {
                index -= 2;
                for (int i = 0; i < VillagerSprites.Length; i++)
                {
                    VillagerSprites[i].transform.Translate(0, -0.25f, 0);
                }
            }
            else
            {
                for (int i = 0; i < VillagerSprites.Length; i++)
                {
                    VillagerSprites[i].transform.Translate(0, 0.25f, 0);
                }
            }
            CharacterSprite.sprite = Sprites[index];
            timer = 50;
        }
    }
}
