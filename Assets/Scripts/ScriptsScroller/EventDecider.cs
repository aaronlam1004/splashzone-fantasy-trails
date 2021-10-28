using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDecider : MonoBehaviour
{
    // 1-6 -> nothing (0)
    // 6-15 -> stat check (1)
    // 15-18 -> basic events (3 (good) / 4 (bad))
    // 19-20 -> lucky grabs (5)
    public int GetEventType() 
    {
        int roll = Random.Range(1, 21);
        if (roll == 20) 
        {
            return 5;
        }
        else if (roll >= 15 && roll <= 19) 
        {
            int flip = Random.Range(0, 2);
            if (flip == 1) 
            { 
                return 3; 
            }
            else 
            { 
                return 4; 
            }
        }
        else if (roll >= 6 && roll <= 15) 
        {
            return 2;
        }
        else 
        {
            return 0;
        }
    }
}
