using Assets.Scripts.Car;
using System;
using UnityEngine;

namespace PlayerInput
{
    public class JoystickInput : MonoBehaviour
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private Joystick _joystick;

        public event Action Moved;

        public bool Moving => _joystick.Direction != Vector2.zero;

        private void Awake()
        {
            Input.multiTouchEnabled = false;
        }

        private void Update()
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

        private void OnDisable()
        {
            _movement?.Stop();
        }
    }
}