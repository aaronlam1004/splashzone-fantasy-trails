using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Help from: https://www.youtube.com/watch?v=R9XMOEFne7w&list=PLV5JKPdDx9OBE9PQm8qTQFcWmW7jsL5Dt
// https://stackoverflow.com/questions/32306704/how-to-pass-data-and-references-between-scenes-in-unity

public class GameController : MonoBehaviour
{
    //[SerializeField] private TimeDistanceManager TimeDistanceManager;
    //[SerializeField] private BackgroundScrolling bg1;
    //[SerializeField] private BackgroundScrolling bg2;
    //[SerializeField] private bool distContd = false;
    //[SerializeField] private bool timeContd = false;
    //[SerializeField] private bool bgContd = false;
    //[SerializeField] private bool spawnContd = false;

    // Handle Event Screens
    // [SerializeField] private FoodItemManager FoodItemManager;

    // Handle Player Event Trigger on Collision
    [SerializeField] private EventSpawner EventSpawner;
    [SerializeField] private PlayerController PlayerController;
    private bool playerTriggered = false;
    private int playerEventPortal;

    private void Start()
    {
    }

    void Update()
    {
        //playerTriggered = PlayerController.EventIsTriggered;
        //playerEventPortal = PlayerController.EventTypeTriggered;

        if (playerTriggered)
        {
            // Time.timeScale = 0;
            if (playerEventPortal == 0 || playerEventPortal == 1 || playerEventPortal == 2)
            {
                Time.timeScale = 0f;
                SceneManager.LoadScene("EventRandomFood");
            }
            else if (playerEventPortal == 3)
            {
                // Debug.Log("WORKING 3");
                playerTriggered = false;
            }
            else if (playerEventPortal == 4)
            {
                // Debug.Log("WORKING 4");
                playerTriggered = false;
            }
            else if (playerEventPortal == 5)
            {
                // Debug.Log("WORKING 5");
                playerTriggered = false;
            }
            else if (playerEventPortal == 6)
            {
                // Debug.Log("WORKING 6");
                playerTriggered = false;
            }
            else if (playerEventPortal == 7)
            {
                // Debug.Log("WORKING 7");
                playerTriggered = false;
            }
            else if (playerEventPortal == 8)
            {
                // Debug.Log("WORKING 8");
                playerTriggered = false;
            }
            else if (playerEventPortal == 9)
            {
                // Debug.Log("WORKING 9");
                playerTriggered = false;
            }
            else if (playerEventPortal == 10)
            {
                // Debug.Log("WORKING 10");
                playerTriggered = false;
            }
        }
        else
        {

        }
    }
}
