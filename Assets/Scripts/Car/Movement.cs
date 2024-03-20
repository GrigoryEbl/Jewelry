using System;
using UnityEngine;
using YG;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private float _speed;
    private Rigidbody _rigidbody;

    public float Speed => _speed;
    public float CurrentSpeed { get; private set; }
    public int Level { get; private set; }
    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init()
    {
        _speed = YandexGame.savesData.EngineSpeed;
        Level = YandexGame.savesData.EngineLevel;
    }

    public void Move(Vector3 direction)
    {
        _transform.LookAt(_transform.position + direction.normalized);
        _rigidbody.velocity = direction * _speed;
        CurrentSpeed = _rigidbody.velocity.sqrMagnitude ;
        IsMoving = true;
    }

    public void Stop()
    {
        if (_rigidbody != null)
            _rigidbody.velocity = Vector3.zero;
        IsMoving = false;
    }

    public void Upgrade(float addedSpeed)
    {
        _speed += addedSpeed;
        Level++;
    }
}
