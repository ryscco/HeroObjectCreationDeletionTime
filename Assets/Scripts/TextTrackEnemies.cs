using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrackEnemies : MonoBehaviour
{
    public Text thisText;
    void Start()
    {
        thisText = GetComponent<Text>();
    }
    void Update()
    {
        thisText.text = "Enemies in world: " + (GameObject.FindGameObjectsWithTag("Enemy").Length);
    }
}