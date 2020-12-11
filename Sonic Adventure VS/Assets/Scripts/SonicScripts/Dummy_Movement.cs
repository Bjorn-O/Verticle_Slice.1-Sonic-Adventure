using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_Movement : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] private float _speed;

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal") * -1;
        float ver = Input.GetAxisRaw("Vertical") * -1;
        Vector3 dir = new Vector3(hor, 0f, ver);

        if (dir.magnitude >= 0.1f)
        {
            controller.Move(dir * _speed * Time.deltaTime);
        }
    }
}
