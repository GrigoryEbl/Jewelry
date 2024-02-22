using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private int _cameraPositionZ;
    [SerializeField] private int _cameraPositionY;
    [SerializeField] private int _zoomValue;
    [SerializeField] private UpgraderView _upgradeView;

    private Vector3 _target;
    private Transform _transform;
    private int _positionZ;

    private void Awake()
    {
        _transform = transform;
        _positionZ = _cameraPositionZ;
    }

    private void Update()
    {
        _target = _player.position;
        _target.z += _cameraPositionZ;
        _target.y += _cameraPositionY;
        _transform.position = Vector3.Lerp(_transform.position, _target, Time.deltaTime * _speed);
    }

    private void OnEnable()
    {
        _upgradeView.OpenPanel += Zoom;
    }

    private void OnDisable()
    {
        _upgradeView.OpenPanel -= Zoom;
    }

    private void Zoom(bool isOpen)
    {
        if (isOpen)
        {
            _cameraPositionZ = _zoomValue;
        }
        else
        {
            _cameraPositionZ = _positionZ;
        }
    }
}
