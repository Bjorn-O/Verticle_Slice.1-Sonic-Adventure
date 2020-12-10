using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ThirdPersonCamera : MonoBehaviour
{
    float yaw;
    float pitch; 

    public float mouseSens = 10; 
    public Transform target;
    public float dstFromTarget = 2;
    public Vector2 PitchMinMax = new Vector2(-8, 85);

    public float rotationSmoothTime = .12f; 
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation; 

    // Update is called once per frame
    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSens;
        pitch -= Input.GetAxis("Mouse Y") *mouseSens;
        pitch = Mathf.Clamp(pitch, PitchMinMax.x, PitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation,new Vector3 (pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

        transform.eulerAngles = currentRotation; 

        transform.position = target.position - transform.forward * dstFromTarget; 

    }
}
