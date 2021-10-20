using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvent : LevelObject_BASE
{
    [SerializeField] private Camera _mainCam;
    [SerializeField] private Camera _eventCamera;
    private GameObject orca;
    [SerializeField] private Animator _anim;

    [SerializeField] private int _timeToFade;
    [SerializeField] private int _timeToOrca;

    void Start()
    {
        _eventCamera.enabled = false;
        orca = GameObject.Find("_rca FBX");
    }

    protected override void OnPlayerInteraction(GameObject player)
    {
        base.OnPlayerInteraction(player);
        _eventCamera.enabled = true;
        _mainCam.enabled = false;
        _anim.SetTrigger("OrcaRotate");
    }
}