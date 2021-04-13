using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D playerRB2D;
    public float speed = 1f;
    public float rotateSpeed = 1f;

    // Control scheme false = mouse, true = keys
    public bool controlScheme;
    // Start is called before the first frame update
    void Start()
    {
        controlScheme = false; // default mouse control
        playerRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            Debug.Log("Contorl scheme changed " + controlScheme);
            controlScheme = !controlScheme;
        }

        if (controlScheme)
        {
            Vector3 pos = playerRB2D.transform.position;

            if (Input.GetKey("w"))
            {
                pos.y += speed;
            }

            if (Input.GetKey("a"))
            {
                playerRB2D.transform.Rotate(Vector3.forward * rotateSpeed);
            }

            if (Input.GetKey("s"))
            {
                pos.y -= speed;
            }

            if (Input.GetKey("d"))
            {
                playerRB2D.transform.Rotate(Vector3.forward * -rotateSpeed);
            }

            playerRB2D.transform.position = pos;
        }
        else
        {

        }
    }
}
