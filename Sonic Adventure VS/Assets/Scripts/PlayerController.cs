using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 2;
    public float runSpeed = 6; 

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity; 
    Transform cameraT;
    // Start is called before the first frame update
    void Start()
    {
        cameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero) {
        float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y; 
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        bool running = Input.GetKey (KeyCode.LeftShift);
        float speed =  ((running) ? runSpeed : walkSpeed) * inputDir.magnitude; 

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World); 
    }
}
