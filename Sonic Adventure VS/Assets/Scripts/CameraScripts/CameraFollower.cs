using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private GameObject _targetSonic;
    private Transform _targetRotation;

    public float cameraDistance;
    public float rotationSmoothTime= 1.2f;
    private Vector3 rotationSmoothVelocity;
    private Vector3 currentRotation;

    public float pitch;

    void Start()
    {
        _targetSonic = GameObject.Find("Sonic(Clone)");
        _targetRotation = _targetSonic.transform.Find("Forward");
    }

    void Update()
    {
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, _targetRotation.eulerAngles.y, 0f), ref rotationSmoothVelocity, rotationSmoothTime);
        Vector3 targetRotation = new Vector3(pitch, _targetRotation.eulerAngles.y, 0f);
        transform.eulerAngles = currentRotation;

        transform.position = (_targetSonic.transform.position + new Vector3(0f, 5f, 0f)) - transform.forward * cameraDistance;
    }
}
