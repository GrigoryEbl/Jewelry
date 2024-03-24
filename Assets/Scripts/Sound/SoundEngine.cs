using UnityEngine;

public class SoundEngine : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _maxPitch;
    [SerializeField] private float _minPitch;

    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _audioSource.Play();
    }

    private void Update()
    {
        if (_movement.IsMoving)
        {
            _audioSource.pitch = Mathf.InverseLerp(_minPitch, _maxPitch, _movement.CurrentSpeed) * _maxPitch;
            //_audioSource.pitch = Mathf.Lerp(_normalPitch, _maxPitch, _movement.CurrentSpeed);
            //_audioSource.pitch = _movement.CurrentSpeed / _maxPitch;
        }
        else
        { 
            _audioSource.pitch = _minPitch;
        }
    }
}
