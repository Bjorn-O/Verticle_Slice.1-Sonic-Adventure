using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGate : LevelObject_BASE
{
    [SerializeField] private GameObject _spikeEffect;
    [SerializeField] private Transform _spikeLoc;
    [SerializeField] private float _attackTimer;
    private Animator _anim;
    private float _currentTimer;
    private bool _isIdle;

    void Start()
    {
        _isIdle = true;
        _anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (_isIdle)
        {
            _currentTimer += Time.deltaTime;
        }
        if (_currentTimer >= _attackTimer)
        {
            _isIdle = false;
            Attack();
        }
    }

    protected override void OnPlayerInteraction(GameObject player)
    {
        base.OnPlayerInteraction(player);
        player.GetComponent<GameManager.SonicTracker>().GetHurt();
    }

    private void OnDrop()
    {
        _soundEffect[0].Play();
        //Particle Effect in the works
        //Instantiate(_spikeEffect, _spikeLoc.position, Quaternion.identity);
    }

    private void ResetGate()
    {
        _anim.ResetTrigger("Gate_Attack");
        _currentTimer = 0;
        _isIdle = true;
    }

    private void Attack()
    {
        _anim.SetTrigger("Gate_Attack");
    }
}
