using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 20f;
    public float rotateSpeed = 1f;

    // Control scheme false = mouse, true = keys
    public bool controlScheme;
    // Start is called before the first frame update
    void Start()
    {
        controlScheme = false; // default mouse control
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            Debug.Log("Contorl scheme changed " + controlScheme);
            controlScheme = !controlScheme;
        }

        Vector3 pos = transform.position;

        if (controlScheme)
        {
            if (Input.GetKey("w"))
            {
                pos.y += speed;
            }

            if (Input.GetKey("a"))
            {
                transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
            }

            if (Input.GetKey("s"))
            {
            }

            if (Input.GetKey("d"))
            {
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            }
        }
        else
        {

        }

        transform.position = pos;
    }
}
