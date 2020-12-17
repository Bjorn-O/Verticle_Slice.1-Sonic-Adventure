using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonic_Movement_v2 : MonoBehaviour
{
    [SerializeField] private float downForce;
    [SerializeField] private float _accelerateSpeed;
    [SerializeField] private float _decelerateSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _strafeSpeed;

    private SonicXRotation xRotation;
    private Vector3 _lastPosition;

    private float _currentSpeed;
    private float lockSeconds;
    private bool onLockedByRamp;

    public Rigidbody _rb;
    public Vector3 _dir;
    public Transform _cam;

    public float currentVelocity;
    public bool isLocked = false;


    void Start()
    {
        xRotation = GetComponent<SonicXRotation>();
        _rb = GetComponent<Rigidbody>();
        _cam = Camera.main.transform;
    }

    void Update()
    {
        if (isLocked)
        {
            _dir = Vector3.forward;
        } else {
            _dir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
            Accelerator();
        }
        currentVelocity = _rb.velocity.magnitude;
    }

    void FixedUpdate()
    {
        if (xRotation.isGrounded && !isLocked)
        {
            _rb.AddForce(-transform.up * downForce);
        }

        Vector3 tempVec3;
        _rb.useGravity = !(isLocked && !onLockedByRamp);

        if (isLocked)
        {
            tempVec3 = transform.GetChild(0).forward;
            tempVec3 *= _currentSpeed;  
        } else
        {
            tempVec3 = _cam.TransformVector(_dir);
            if (xRotation.isGrounded)
            {
                tempVec3 *= _currentSpeed;
            }
            else
            {
                tempVec3 *= _strafeSpeed;
            }
            tempVec3.y = _rb.velocity.y;
        }
        if (!onLockedByRamp)
        {
            _rb.velocity = tempVec3;
        }
    }

    public void Locking(float seconds, float boostSpeed, bool isRamp)
    {
        onLockedByRamp = isRamp;
        isLocked = true;
        lockSeconds = seconds;
        StartCoroutine("Looping");
        _currentSpeed = boostSpeed;
    }

    private IEnumerator Looping()
    {
        yield return new WaitForSeconds(lockSeconds);
        onLockedByRamp = false;
        isLocked = false;
    }

    private void Accelerator()
    {
        if (_dir.magnitude > 0 && _currentSpeed <= _maxSpeed && xRotation.isGrounded)
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
