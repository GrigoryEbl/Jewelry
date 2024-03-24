using System;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Joystick _joystick;

    public bool Moving => _joystick.Direction != Vector2.zero;
    
    public event Action Moved;

    private void Awake()
    {
        Input.multiTouchEnabled = false;
    }

    private void OnDisable()
    {
        _movement?.Stop();
    }

    public void Update()
    {
        if (Moving == false)
        {
            _movement.Stop();
            return;
        }

        Vector3 direction = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);

        _movement.Move(direction);
        Moved?.Invoke();
    }
}
