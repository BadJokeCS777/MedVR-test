using System;
using Mirror;
using UnityEngine;

public class CameraFollow : NetworkBehaviour
{
    private Transform _camera;

    private void Start()
    {
        if (isLocalPlayer == false)
            return;
        
        _camera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if (isLocalPlayer == false)
            return;

        _camera.SetPositionAndRotation(transform.position, transform.rotation);
    }
}