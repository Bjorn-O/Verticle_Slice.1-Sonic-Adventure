using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonic_Movement_v2 : MonoBehaviour
{
    private float _currentSpeed;
    [SerializeField] private float _accelerateSpeed;
    [SerializeField] private float _decelerateSpeed;

    public Rigidbody _rb;
    public Vector3 _dir;
    public Transform _cam;

    private Vector3 _lastPosition;
    public float currentVelocity;

    [SerializeField] private float _maxSpeed;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _cam = Camera.main.transform;
    }

    void Update()
    {
        _dir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        currentVelocity = _rb.velocity.magnitude;
        Accelerator();
    }

    void FixedUpdate()
    {
        Vector3 tempVec3 = _cam.TransformVector(_dir);
        tempVec3 *= _currentSpeed;
        tempVec3.y = _rb.velocity.y;
        _rb.velocity = tempVec3;
    }

    //Speedometer and InputChecker are helper functions, in the future I will write these in their own seperate script. 
    // public float Spedometer(Vector3 pastPosition)
    // {
    //     Vector3 difference = transform.position - pastPosition;
    //     return difference.magnitude * 100;
    // } 

        private void Accelerator()
    {
        if (_dir.magnitude > 0 && _currentSpeed <= _maxSpeed)
        {
            if (_currentSpeed < _maxSpeed / 2)
            {
                _currentSpeed += _accelerateSpeed * 2 * Time.deltaTime;
            }
            else
            {
                _currentSpeed += _accelerateSpeed * Time.deltaTime;
            }
        } 
        else if (_currentSpeed > 0 && _dir.magnitude == 0)
        {
            _currentSpeed -= _decelerateSpeed * Time.deltaTime;
        }
    }
}
