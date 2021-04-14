using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float rotateSpeed = 135;
    void Update()
    {
        transform.Rotate(transform.forward, rotateSpeed * Time.smoothDeltaTime);
    }
    public void setRotateSpeed(float num)
    {
        rotateSpeed *= num;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}