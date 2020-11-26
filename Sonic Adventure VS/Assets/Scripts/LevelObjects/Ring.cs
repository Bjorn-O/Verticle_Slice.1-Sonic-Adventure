using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : LevelObject_BASE
{   
    [SerializeField] protected bool isDropped;

    void Start()
    {
        if (isDropped)
        {
            StartCoroutine("Fade");
        }
    }

    IEnumerator Fade()
    {
        Destroy(this.gameObject);
        return null;
    }

    protected override void OnTriggerEnter(Collider player)
    {
        base.OnTriggerEnter(player);
        sonicTracker.ringCount += 1;
        Destroy(this.gameObject);
    }
}
