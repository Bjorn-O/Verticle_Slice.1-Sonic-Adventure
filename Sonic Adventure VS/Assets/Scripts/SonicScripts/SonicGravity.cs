using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicGravity : MonoBehaviour
{
    public bool useGravity = true;
    private Rigidbody _rb;

    void Awake() 
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rb.useGravity = false;

        if (useGravity)
        {
            _rb.AddForce(Physics.gravity * (_rb.mass * _rb.mass));
        }
    }
}
