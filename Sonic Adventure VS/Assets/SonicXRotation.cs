using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicXRotation : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float _rcLength;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _lockedRotateSpeed;

    private Sonic_Movement_v2 _mov;

    void Start()
    {
        _mov = GetComponent<Sonic_Movement_v2>();
    }

    void Update()
    {
        GroundAllignment();
        Debug.Log(isGrounded);
    }

    void GroundAllignment()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + transform.up * (_rcLength/2) , -transform.up, out hit , _rcLength, layerMask))
        {
            float speed = _rotateSpeed;

            if (_mov.isLocked)
            {
                speed = _lockedRotateSpeed;
            }
            
            transform.up = Vector3.Lerp(transform.up, hit.normal, speed * Time.deltaTime);
            isGrounded = true;
        }
        else {
            transform.up = Vector3.Lerp(transform.up, Vector3.up, _rotateSpeed * Time.deltaTime);
            isGrounded = false;
        }
    }
}
