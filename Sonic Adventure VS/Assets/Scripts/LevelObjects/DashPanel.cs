using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPanel : LevelObject_BASE
{
    private Sonic_Movement_v2 _mov;

    [SerializeField] private float _boostSpeed;
    [SerializeField] private float _boostTime;
    [SerializeField] private bool isRamp;
    [SerializeField] private Transform angle;

    void Start()
    {
        _mov = FindObjectOfType<Sonic_Movement_v2>();
        angle = transform.Find("Angle");
    }

    protected override void OnPlayerInteraction(GameObject player)
    {
        base.OnPlayerInteraction(player);
        _soundEffect[0].Play();

        if (!isRamp)
        {
            _mov.transform.position = this.transform.position;
            _mov.transform.GetChild(0).forward = this.transform.forward;
        }
        else
        {
            _mov.transform.position = angle.transform.position;
        }
        _mov.Locking(_boostTime, _boostSpeed, isRamp);
        if (isRamp)
        {
            _mov._rb.velocity = angle.forward * _boostSpeed;
        }

    }
}
