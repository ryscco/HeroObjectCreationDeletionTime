using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public Text enemyCountText = null;
    public float moveSpeed = 20f;
    public float maxMoveSpeed = 150f;
    public float rotateSpeed = 90f / 2f; // 90-degrees in 2 seconds
    public float accelerationFactor = 0.15f;
    public bool controlScheme = true; // true is mouse, false is keyboard
    private int numPlanesTouched = 0;

    // private GameController mGameGameController = null;

    void Start()
    {
        // mGameGameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            controlScheme = !controlScheme;
            moveSpeed = 20f;
        }
        Vector3 pos = transform.position;

        if (controlScheme)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log("Position is " + pos);
            pos.z = 0f;  // <-- this is VERY IMPORTANT!
            // Debug.Log("Screen Point:" + Input.mousePosition + "  World Point:" + p);
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

            if ((moveSpeed > 20) && !(Input.GetKey("w") || Input.GetKey("s")))
            {
                moveSpeed -= accelerationFactor;
            }

            if (Input.GetKey("a"))
            {
                transform.Rotate(transform.forward, rotateSpeed * Time.smoothDeltaTime);
            }

            if (Input.GetKey("d"))
            {
                transform.Rotate(transform.forward, -rotateSpeed * Time.smoothDeltaTime);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = Instantiate(Resources.Load("Prefabs/Projectile") as GameObject);
            bullet.transform.localPosition = transform.localPosition;
            bullet.transform.rotation = transform.rotation;
            Debug.Log("Spawn Projectile:" + bullet.transform.localPosition);
        }
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Here x Plane: OnTriggerEnter2D");
        numPlanesTouched = numPlanesTouched + 1;
        enemyCountText.text = "Planes touched = " + numPlanesTouched;
        Destroy(collision.gameObject);
        // mGameGameController.EnemyDestroyed();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Here x Plane: OnTriggerStay2D");
    }
}