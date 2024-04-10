using Item;
using Sounds;
using System;
using UnityEngine;
using YG;

namespace PlayerCar
{
    [RequireComponent(typeof(Attractor))]
    public class Magnet : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private float _catchDistance;
        [SerializeField] private PlayerEffect _playerEffect;

        private int _maxCapacityCount;
        private Attractor _attractor;
        private Transform _transform;
        private float _startCatchDistance = 0.4f;
        private float _addedCathDistance = 0.05f;

        public Action<int> ResourceChangedCount;

        public int Level { get; private set; }
        public int MaxCapacityCount => _maxCapacityCount;

        private void Awake()
        {
            _transform = transform;
            _attractor = GetComponent<Attractor>();
        }

        public void Init()
        {
            Level = YandexGame.savesData.MagnetLevel;
            _maxCapacityCount = YandexGame.savesData.CapacityLevel;
        }

        public void ChangeMaxCapacityCount(int value)
        {
            _maxCapacityCount += value;
        }

        public void ChangeLevel(int level)
        {
            Level = level;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.transform.parent == _transform)
                return;

            if (_transform.childCount >= _maxCapacityCount)
                return;

            if (other.TryGetComponent(out CollectedItem item) && item.TryGetComponent(out Rigidbody rigidbody))
            {
                if (Level < item.Level)
                    return;

                _attractor.Attract(item.transform, _transform, _force);
                Catch(item, rigidbody);
            }

            if (_transform.childCount == 0)
                _catchDistance = _startCatchDistance;

            ResourceChangedCount?.Invoke(_transform.childCount);
        }

        private void Catch(CollectedItem item, Rigidbody rigidbody)
        {
            if (Vector3.Distance(item.transform.position, _transform.position) <= _catchDistance)
            {
                item.transform.parent = _transform;
                rigidbody.isKinematic = true;
                AddCathDistance();
                _playerEffect.Play();
            }
        }

        private void AddCathDistance()
        {
            _catchDistance += _addedCathDistance;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _catchDistance);
        }
    }
}
