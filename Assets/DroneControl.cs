using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    public float rotateSpeed = 1.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d")) {
            transform.Rotate(Vector3.forward * -rotateSpeed);
        }

        if (Input.GetKey("a")) {
            transform.Rotate(Vector3.forward * rotateSpeed);
        }
    }
}
