using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : LevelObject_BASE
{   
    [SerializeField] protected bool isDropped;
    [SerializeField] private GameObject _pickUpEffect;
    private MeshRenderer _meshR;
    private Rigidbody _rigB;
    private Collider _col;
    private int _blinkTime;

    void Start()
    {
        if (isDropped)
        {
            _col = GetComponent<Collider>();
            _meshR = GetComponentInChildren<MeshRenderer>();
            _rigB = GetComponent<Rigidbody>();
            StartCoroutine(Fade(3,2));
            _rigB.AddForce(transform.forward * 70f + transform.up *45f);
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.tag == "Terrain" && isDropped == true)
        {
            _rigB.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    IEnumerator Fade(float blinkDelay, float destroyDelay)
    {
        yield return new WaitForSeconds(0.5f);
        _col.enabled = true;
        yield return new WaitForSecondsRealtime(blinkDelay);
        while(_blinkTime < 10)
        {
            switch (_meshR.enabled)
            {
                case true:
                    _meshR.enabled = false;
                    break;
                case false:
                    _meshR.enabled = true;
                    break;
            }
            _blinkTime += 1;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(this.gameObject);
    }

    protected override void OnPlayerInteraction(GameObject player)
    {
        base.OnPlayerInteraction(player);
        Instantiate(_pickUpEffect, this.transform.position, this.transform.rotation);
        player.GetComponent<GameManager.SonicTracker>().setRings(1);
        Destroy(this.gameObject);
    }
}
