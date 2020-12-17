using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvent : LevelObject_BASE
{
    [SerializeField] private Camera _mainCam;
    [SerializeField] private Camera _eventCamera;
    [SerializeField] private GameObject orca;
    [SerializeField] private float _stallTime;
    [SerializeField] private float speed;

    private MeshRenderer _renderer;

    void Start()
    {
        _renderer = orca.GetComponent<MeshRenderer>();
        _eventCamera.enabled = false;
    }

    // Start is called before the first frame update
    protected override void OnPlayerInteraction(GameObject player)
    {
        base.OnPlayerInteraction(player);
        _eventCamera.enabled = true;
        _mainCam.enabled = false;
        StartCoroutine("CameraDelay", _stallTime);
    }

    private IEnumerator CameraDelay(float time)
    {
        yield return new WaitForSeconds(time);
        while (Vector3.Distance(_eventCamera.transform.position, _mainCam.transform.position) > 0.001f)
        {   
            float step = speed * Time.deltaTime;
            _eventCamera.transform.position = Vector3.MoveTowards(_eventCamera.transform.position, _eventCamera.transform.position, step);
        }
        _mainCam.enabled = true;
        _eventCamera.enabled = false;
    }
}
