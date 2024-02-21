using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private int _cameraPositionZ;
    [SerializeField] private int _cameraPositionY;

    private Vector3 _target;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _target = _player.position;
        _target.z += _cameraPositionZ;
        _target.y += _cameraPositionY;
        _transform.position = Vector3.Lerp(_transform.position, _target, Time.deltaTime * _speed);
    }
}
