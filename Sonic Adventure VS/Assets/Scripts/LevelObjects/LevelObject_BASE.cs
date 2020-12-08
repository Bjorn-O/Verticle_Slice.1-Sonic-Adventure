using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject_BASE : MonoBehaviour
{
    [SerializeField] protected AudioSource[] _soundEffect;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sonic")
        {
            OnPlayerInteraction(other.gameObject);
        }
    }

    protected virtual void OnPlayerInteraction(GameObject player)
    {
        print("This is one interaction");
    }
}
