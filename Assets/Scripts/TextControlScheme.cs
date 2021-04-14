using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControlScheme : MonoBehaviour
{
    public Text thisText;
    void Start()
    {
        thisText = GetComponent<Text>();
    }
    void Update()
    {
        if (GameObject.FindObjectOfType<PlayerBehavior>().controlScheme == true)
        {
            thisText.text = "Control scheme: Mouse";
        }
        else
        {
            thisText.text = "Control scheme: Keyboard";
        }
    }
}