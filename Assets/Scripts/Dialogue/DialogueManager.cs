using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Help from: https://www.youtube.com/watch?v=_nRzoTzeyxU

public class DialogueManager : MonoBehaviour
{
    private Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // StopAllCoroutines();
        // StartCoroutine(TypeOutSentence(sentence));
    }

    // Coroutine to print letters of a sentence one-by-one
    IEnumerator TypeOutSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char l in sentence.ToCharArray())
        {
            dialogueText.text += l;
            yield return null;
        }
    }
}
