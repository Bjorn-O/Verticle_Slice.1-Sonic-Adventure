using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring_Effect : MonoBehaviour
{
    void Awake()
    {
        Destroy(this.gameObject, .810f);
    }
}
