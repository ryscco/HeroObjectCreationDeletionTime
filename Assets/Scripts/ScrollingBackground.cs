using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed;
    public Renderer BGRenderer;
    void Start()
    {
        
    }
    void Update()
    {
        BGRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, scrollSpeed * Time.deltaTime);
    }
}