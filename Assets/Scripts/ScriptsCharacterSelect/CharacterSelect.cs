using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField]
    TMP_InputField[] villagerNames;

    public void BeginJourney() {
        Debug.Log(villagerNames[0].text);
    }
}
