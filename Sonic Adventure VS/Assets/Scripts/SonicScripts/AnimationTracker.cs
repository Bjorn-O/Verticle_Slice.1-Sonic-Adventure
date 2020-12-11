using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTracker : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private Animator _animator;
    void Awake()
    {
        //Snags the character controller that commands the entire character
        _controller = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //This takes sets Sonic's overal momentum to a float we use to measure in the animator.
        _animator.SetFloat("Velocity", _controller.velocity.magnitude);

        //This IF-Statement checks if Sonic's feet are touching the ground or not, if not, the Any-State animation falling will occur.
        if (_controller.isGrounded)
        {
            _animator.SetBool("Grounded", false);
        } else {
            _animator.SetBool("Grounded", true);
        }
    }
}
