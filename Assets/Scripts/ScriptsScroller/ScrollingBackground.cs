using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from https://www.youtube.com/watch?v=U3sT-T5bKX4&list=WL&index=101

public class ScrollingBackground : MonoBehaviour
{
    public float backSpeed;
    public Renderer backRenderer;

    // Update is called once per frame
    void Update()
    {
        backRenderer.material.mainTextureOffset += new Vector2(-1 *backSpeed * Time.deltaTime, 0);
    }
}
