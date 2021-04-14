using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEnemyTouchCount : MonoBehaviour
{
    public Text thisText;
    void Start()
    {
        thisText = GetComponent<Text>();
    }
    void Update()
    {
        thisText.text = "Enemies touched: " + GameObject.FindObjectOfType<GameController>().numberOfEnemiesTouched;
    }
}