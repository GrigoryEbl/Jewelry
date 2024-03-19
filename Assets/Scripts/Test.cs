using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private TMP_Text _speed;
    [SerializeField] private TMP_Text _fpsText;
    [SerializeField] private TMP_Text _timeText;

    private float _fps;

    private void Update()
    {
        _fps = 1.0f / Time.deltaTime;
        _speed.text = $"Speed: {_movement.Speed}"; 
        _fpsText.text = $"FPS:{(int)_fps}";
        _timeText.text = $"Play time: {Time.time.ToString("F2")}";
    }
}