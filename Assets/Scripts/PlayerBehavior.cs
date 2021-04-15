using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float maxMoveSpeed = 150f;
    public float rotateSpeed = 180f / 2f; // 180-degrees in 2 seconds
    public float accelerationFactor = 0.15f;
    public bool controlScheme = true; // true is mouse, false is keyboard
    public float shootCooldownTime = 0.2f;
    private bool shootCooldownToggle = false;
    private float nextFireTime = 0;
    private GameController mGameGameController = null;
    private float spriteSizeX = 0;
    private float spriteSizeY = 0;
    void Start()
    {
        mGameGameController = FindObjectOfType<GameController>();
        spriteSizeX = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        spriteSizeY = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
    }
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            controlScheme = !controlScheme;
            moveSpeed = 20f;
        }
        Vector3 pos = transform.position;

        if (controlScheme) // Default scheme is player locked to mouse
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
        }
        else
        {
            if (Input.GetKey("w") || Input.GetKey("s"))
            {
                if (moveSpeed < maxMoveSpeed)
                {
                    moveSpeed += accelerationFactor;
                }
                else if (moveSpeed == maxMoveSpeed)
                {
                    moveSpeed = maxMoveSpeed;
                }
                if (Input.GetKey("w"))
                {
                    pos += ((moveSpeed * Time.smoothDeltaTime) * transform.up);

                }
                if (Input.GetKey("s"))
                {
                    pos -= ((moveSpeed * Time.smoothDeltaTime) * transform.up);

                }
            }
            // Decelerate player when movement keys aren't held
            if ((moveSpeed > 20) && !(Input.GetKey("w") || Input.GetKey("s")))
            {
                moveSpeed -= accelerationFactor;
            }
            // Check player position for edge transitioning
            if (pos.x < -140)
            {
                pos.x = 140;
            }
            if (pos.y > 110)
            {
                pos.y = -110;
            }
            if (pos.x > 140)
            {
                pos.x = -140;
            }
            if (pos.y < -110)
            {
                pos.y = 110;
            }
        }
        // Rotation active during both control schemes
        if (Input.GetKey("a"))
        {
            transform.Rotate(transform.forward, rotateSpeed * Time.smoothDeltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(transform.forward, -rotateSpeed * Time.smoothDeltaTime);
        }
        // Constrain fire rate
        if (Time.time > nextFireTime)
        {
            if (shootCooldownToggle)
            {
                shootCooldownToggle = false;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject projectile = Instantiate(Resources.Load("Prefabs/Projectile") as GameObject);
                projectile.transform.localPosition = transform.localPosition;
                projectile.transform.rotation = transform.rotation;
                nextFireTime = Time.time + shootCooldownTime;
            }
        }
        // Update position based on any inputs
        transform.position = pos;
    }
}