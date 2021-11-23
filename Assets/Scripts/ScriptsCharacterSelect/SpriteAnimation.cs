using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public Image image;
    public int spritePerFrame = 2;
    public int animationSpeed = 60;

    int index = CharacterSelect.chosenHero * 2;
    int initIndex = CharacterSelect.chosenHero * 2;

    void Update() 
    {
        if ((int) (initIndex / 2) != CharacterSelect.chosenHero)
        {
            index = CharacterSelect.chosenHero * 2;
            initIndex = CharacterSelect.chosenHero * 2;
        }
        
        if (animationSpeed > 0)
        {
            animationSpeed -= 1;
        }
        else 
        {
            animationSpeed = 60;
            index++;
            if (index == initIndex + 2)
            {
                index = CharacterSelect.chosenHero * 2;
            }
            image.sprite = sprites[index];
        }
    }

}
