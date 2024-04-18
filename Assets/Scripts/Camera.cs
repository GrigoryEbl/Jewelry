using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private int _cameraPositionZ;
        [SerializeField] private int _cameraPositionY;
        [SerializeField] private int _zoomValue;
        [SerializeField] private Upgrader _upgrader;

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
            _transform.position = _target;
        }

        private void OnEnable()
        {
            _upgrader.UpgradeZoneReached += Zoom;
        }

        private void OnDisable()
        {
            _upgrader.UpgradeZoneReached -= Zoom;
        }

        private void Zoom(bool isReach)
        {
            if (isReach)
            {
                _cameraPositionZ = _zoomValue;
            }
            else
            {
                _cameraPositionZ = _positionZ;
            }
        }
    }
}