using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : LevelObject_BASE
{
    protected override void OnTriggerEnter(Collider player)
    {
        base.OnTriggerEnter(player);

        if (isPlayer)
        {
            SetCheckPoint();
        }
    }

    void SetCheckPoint()
    {
        
    }
}
