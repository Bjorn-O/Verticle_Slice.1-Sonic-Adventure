using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject_BASE : MonoBehaviour
{
    public Rigidbody rb;
    protected bool isPlayer;


    protected virtual void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            Debug.Log(player.name + " Passed through " + this.name);
            isPlayer = true;
        }
    }
}
