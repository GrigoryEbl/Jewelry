using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Magnet _magnet;
    [SerializeField] private TMP_Text _speed;
    [SerializeField] private TMP_Text _magnetLevel;
    [SerializeField] private TMP_Text _maxCapacity;
    [SerializeField] private TMP_Text _currSpeed;
    [SerializeField] private TMP_Text _fpsText;
    [SerializeField] private TMP_Text _timeText;

    private float _fps;

    private void Update()
    {
        _fps = 1.0f / Time.deltaTime;
        _speed.text = $"Speed: {_movement.Speed}";
        _currSpeed.text = $"CurrSpeed: {_movement.CurrentSpeed}";
        _fpsText.text = $"FPS:{(int)_fps}";
        _timeText.text = $"Play time: {Time.time.ToString("F2")}";
        _magnetLevel.text = $"Magnet: {_magnet.Level}";
        _maxCapacity.text = $"Capacity: {_magnet.MaxCapacityCount}";
    }
}
