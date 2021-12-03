using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Landmark3Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite[] Sprites;
    [SerializeField] private Image BackgroundImage;

    public void SaveChanges()
    {
        PlayerPrefs.hero.Morale += 20;
        PlayerPrefs.hero.Health += 10;
    }

    int index = 0;
    void Start()
    {
        switch (PlayerPrefs.hero.HeroType)
        {
            case 0:
                index = 0;
                BackgroundImage.sprite = Sprites[index];
                break;
            case 1:
                index = 1;
                BackgroundImage.sprite = Sprites[index];
                break;
            default:
                index = 2;
                BackgroundImage.sprite = Sprites[index];
                break;
        }
        SaveChanges();
    }
}
