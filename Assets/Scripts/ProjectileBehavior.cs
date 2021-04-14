using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public const float projectileSpeed = 40f;
    void Update()
    {
        transform.position += transform.up * (projectileSpeed * Time.smoothDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other);    
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}