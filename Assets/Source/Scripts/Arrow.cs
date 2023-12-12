using System;
using Mirror;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : NetworkBehaviour
{
    [SerializeField, Min(1f)] private float _lifetime;
    [SerializeField] private float _speed;

    private float _lifeTimer;

    public event Action<Arrow> Destroyed;

    private void OnCollisionEnter(Collision collision)
    {
        enabled = false;
        transform.SetParent(collision.transform);
    }

    private void Start()
    {
        _lifeTimer = 0f;
    }

    private void Update()
    {
        if (_lifeTimer > _lifetime)
        {
            DestroySelf();
            return;
        }
        
        float deltaTime = Time.deltaTime;
        _lifeTimer += deltaTime;
        transform.Translate(_speed * deltaTime * transform.forward, Space.World);
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }
    
    [Server]
    private void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }
}