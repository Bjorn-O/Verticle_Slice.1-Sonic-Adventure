using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTracker : MonoBehaviour
{
    private Animator _anim;
    private Sonic_Movement_v2 _mov;
    private SonicXRotation _rot;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _mov = GetComponentInParent<Sonic_Movement_v2>();
        _rot = GetComponentInParent<SonicXRotation>();
    }

    void Update()
    {
        _anim.SetFloat("Velocity", _mov.currentVelocity);
        _anim.SetBool("Grounded", _rot.isGrounded);
    }
}
