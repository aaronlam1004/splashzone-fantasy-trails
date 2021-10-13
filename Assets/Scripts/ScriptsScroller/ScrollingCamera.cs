using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from: https://www.youtube.com/watch?v=U3sT-T5bKX4&list=WL&index=101

public class ScrollingCamera : MonoBehaviour
{
    public float scrollingSpeed;

    void Update()
    {
        transform.position += new Vector3(-1 * scrollingSpeed * Time.deltaTime, 0, 0);
    }

}
