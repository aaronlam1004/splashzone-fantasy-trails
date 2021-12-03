using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Landmark4Manager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score = 0;

    void CalculateScore()
    {
        score += PlayerPrefs.hero.Health + PlayerPrefs.hero.Clothes + PlayerPrefs.hero.Morale;
        score += PlayerPrefs.hero.Aurum;
        score += PlayerPrefs.hero.Intelligence + PlayerPrefs.hero.Dexterity + PlayerPrefs.hero.Strength;
    }

    // Start is called before the first frame update
    void Start()
    {
        CalculateScore();
        scoreText.text = ((int)score).ToString();
    }
}
