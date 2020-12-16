using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTracker : MonoBehaviour
{
    private Animator _anim;
    private Sonic_Movement_v2 _mov;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _mov = GetComponentInParent<Sonic_Movement_v2>();
        _anim.SetBool("Grounded",true);
    }

    void Update()
    {
        _anim.SetFloat("Velocity", _mov.currentVelocity);
    }
}
