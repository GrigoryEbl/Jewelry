using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEngine : MonoBehaviour
{ 
    [SerializeField] private AudioSource _audioSource;

    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _audioSource.Play();
    }

    private void Update()
    {
        _audioSource.pitch = _movement.CurrentSpeed / 10;
    }
}
