using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrackProjectiles : MonoBehaviour
{
    public Text thisText;
    void Start()
    {
        thisText = GetComponent<Text>();
    }
    void Update()
    {
        thisText.text = "Projectiles in world: " + (GameObject.FindGameObjectsWithTag("Projectile").Length);
    }
}