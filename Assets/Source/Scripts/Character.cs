using System;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : NetworkBehaviour
{
    [SerializeField, Min(1f)] private float _lifetime;
    [SerializeField] private Vector2 _speedRange;
    [SerializeField] private Vector2 _moveDurationRange;

    private float _lifeTimer;
    private float _moveTimer;
    private float _speed;
    private float _duration;

    public event Action<Character> Destroyed;
    
    private void Start()
    {
        _lifeTimer = 0;
        
        UpdateValues();
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;

        if (_lifeTimer > _lifetime)
        {
            DestroySelf();
            return;
        }
        
        if (_moveTimer >= _duration)
            UpdateValues();

        transform.Translate(_speed * deltaTime * transform.forward);
        
        _moveTimer += deltaTime;
        _lifeTimer += deltaTime;
    }

    public void Destroy()
    {
        DestroySelf();
    }
    
    private void UpdateValues()
    {
        _moveTimer = 0f;
        _speed = Random.Range(_speedRange.x, _speedRange.y);
        _duration = Random.Range(_moveDurationRange.x, _moveDurationRange.y);
        transform.forward = new Vector3(Random.Range(-1f, 1f),0f, Random.Range(-1f, 1f)).normalized;
    }
    
    [Server]
    private void DestroySelf()
    {
        Destroyed?.Invoke(this);
        NetworkServer.Destroy(gameObject);
    }
}