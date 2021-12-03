using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text titleText;
    [SerializeField] private Text descText;


    void Start()
    {
        PlayerPrefs.hero.Morale = 1;
        if (PlayerPrefs.hero.Health == 0)
        {
            PlayerPrefs.hero.Health = 1;
            titleText.text = "You died.";
            descText.text = "Close your eyes and embrace eternity.";
        }
        else if (PlayerPrefs.hero.Morale == 0)
        {
            PlayerPrefs.hero.Morale = 1;
            titleText.text = "You lose all hope.";
            descText.text = "Abandon everyone and everything.";
        }
        else
        {
            titleText.text = "You died";
            descText.text = "Close your eyes and accept eternity.";
        }
    }
}
