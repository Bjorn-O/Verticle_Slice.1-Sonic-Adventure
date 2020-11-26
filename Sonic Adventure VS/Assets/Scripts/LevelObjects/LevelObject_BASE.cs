using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject_BASE : MonoBehaviour
{
    [SerializeField] protected Collider rb;
    protected bool isPlayer;
    protected GameManager.SonicTracker sonicTracker;

    void Start()
    {
        sonicTracker = FindObjectOfType<GameManager.SonicTracker>();
    }

    protected virtual void OnTriggerEnter(Collider player)
    {
        if (player == sonicTracker)
        {
            Debug.Log(player.name + " Passed through " + this.name);
            isPlayer = true;
        }
    }
}
