using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEngine : MonoBehaviour
{
    [SerializeField] private JoystickInput _joystickInput;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _maxPitch;
    [SerializeField] private float _normalPitch;

    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _audioSource.Play();
    }

    private void Update()
    {

        _audioSource.pitch = Mathf.InverseLerp(_normalPitch, _maxPitch, _movement.CurrentSpeed) * _maxPitch;

        if(_movement.IsMoving == false)
        {
            _audioSource.pitch = _normalPitch;
        }
    }
}
