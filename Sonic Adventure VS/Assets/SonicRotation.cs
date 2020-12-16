using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicRotation : MonoBehaviour
{
    private Sonic_Movement_v2 _mov;
    private Vector3 _lastRotation;
    void Awake()
    {
        //Snags the character controller that commands the entire character
        _mov = GetComponentInParent<Sonic_Movement_v2>();
    }
    void Update()
    {
        RotateCharacter();
    }

    void RotateCharacter()
    {   
        if (_mov._rb.velocity.magnitude > 0)
        {
            Vector3 tempVec = transform.position + _mov._cam.TransformVector(_mov._dir);
            transform.LookAt(tempVec);
            transform.localRotation = new Quaternion(0f, transform.localRotation.y, 0f, transform.localRotation.w);
        }
    }
}
