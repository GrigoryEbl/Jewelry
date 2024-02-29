using System;
using UnityEngine;
using YG;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _transform;

    private Rigidbody _rigidbody;

    public float Speed => _speed;
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
        _transform.LookAt(_transform.position + direction);
        _rigidbody.velocity = direction * _speed;

        IsMoving = true;
    }

    public void Stop()
    {
        if (_rigidbody != null)
            _rigidbody.velocity = Vector3.zero;

        IsMoving = false;
    }

    public void Ugrade(float addedSpeed)
    {
        _speed += addedSpeed;
        Level++;
    }

    internal void GetData()
    {
        throw new NotImplementedException();
    }
}
