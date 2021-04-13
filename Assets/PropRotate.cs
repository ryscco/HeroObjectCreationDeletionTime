using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRotate : MonoBehaviour
{
    public float rotateSpeed = 7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed);
    }
}
