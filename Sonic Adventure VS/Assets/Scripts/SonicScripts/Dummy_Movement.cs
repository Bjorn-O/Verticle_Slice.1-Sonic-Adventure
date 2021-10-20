using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_Movement : MonoBehaviour
{
    public float decelerateSpeed;   
    public float accelerateSpeed;
    public float maxSpeed;
    public float jumpForce;
    public float strafeSpeed;

    private float _airbornSpeed; 
    private float _currentSpeed;
    public float currentSpeed{
        get{
             return _currentSpeed;
        }
    }
    private float _speed;
    private float _currentVelocity;

    private bool _isGrounded = true;
    private bool _isJumping;
    private float _jumpTimeCounter;
    public float jumpTime;

    private float _hor;
    private float _ver;

    public Vector3 _dir;
    private Vector3 _lastPosition;
    private Vector3 _jumpDir = new Vector3(0f, 2f, 0f);

    private Rigidbody _rig;

    void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        _speed = Accelerator(InputChecker());
        PlayerMovement(_speed);
        _currentVelocity = Spedometer(_lastPosition);
        _lastPosition = transform.position;
        print(_isJumping);
    }

    void FixedUpdate()
    {}

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {   
            _isJumping = false;
        }
    }

    private void PlayerMovement(float accelSpeed)
    {
        _hor = Input.GetAxis("Horizontal");
        _ver = Input.GetAxis("Vertical");

        if (_isJumping)
        {
            _dir = new Vector3(_hor * strafeSpeed * Time.deltaTime, 0f, _ver * strafeSpeed * Time.deltaTime);
        } else
        {
            _dir = new Vector3(_hor * accelSpeed * Time.deltaTime, 0f, _ver * accelSpeed * Time.deltaTime);
        }

        transform.position += _dir;
        //transform.Translate(_dir.x, 0f, _dir.z);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isJumping = true;
            _rig.velocity = Vector3.up * jumpForce;
            _jumpTimeCounter = jumpTime;
        } 

        if (Input.GetKey(KeyCode.Space) && _isJumping == true)
        {
            if (_jumpTimeCounter > 0)
            {
                _rig.velocity = Vector3.up * jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }  
    }

    private float Accelerator(bool getInput)
    {
        if (getInput && _currentSpeed <= maxSpeed && !_isJumping)
        {
            if (_currentSpeed < maxSpeed / 2)
            {
                _currentSpeed += accelerateSpeed * 2;
                return _currentSpeed;
            }
            else
            {
                _currentSpeed += accelerateSpeed;
                return _currentSpeed;
            }
        } 
        else if (!getInput && _currentSpeed > 0)
        {
            _currentSpeed -= decelerateSpeed;
            return _currentSpeed;   
        }
        else
        {
            return _currentSpeed;
        }
    }


    //Speedometer and InputChecker are helper functions, in the future I will write these in their own seperate script. 
    public float Spedometer(Vector3 pastPosition)
    {
        Vector3 difference = transform.position - pastPosition;
        return difference.magnitude * 100;
    } 

    public bool InputChecker()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
