using Assets.Scripts.Item;
using Assets.Scripts.Sounds;
using System;
using UnityEngine;
using YG;

namespace Assets.Scripts.Car.Details
{
    [RequireComponent(typeof(Attractor))]
    public class Magnet : MonoBehaviour, IImprovable
    {
        [SerializeField] private float _force;
        [SerializeField] private float _catchDistance;
        [SerializeField] private PlayerEffect _playerEffect;
        [SerializeField] private Capacity _capacity;

        private Attractor _attractor;
        private Transform _transform;
        private float _startCatchDistance = 0.4f;
        private float _addedCathDistance = 0.05f;

        public Action<int> ResourceChangedCount;

        public int Level { get; private set; }

        private void Awake()
        {
            _transform = transform;
            _attractor = GetComponent<Attractor>();
        }

        public void Init()
        {
            Level = YandexGame.savesData.MagnetLevel;
        }

        public void ChangeLevel(int level)
        {
            Level = level;
        }

        public void Upgrade()
        {
            Level++;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.transform.parent == _transform)
                return;

            if (_transform.childCount >= _capacity.Level)
                return;

            if (other.TryGetComponent(out CollectedItem item) && item.TryGetComponent(out Rigidbody rigidbody))
            {
                if (Level < item.Level)
                    return;

                _attractor.Attract(item.transform, _transform, _force);
                Catch(item.transform, rigidbody);
            }

            if (_transform.childCount == 0)
                _catchDistance = _startCatchDistance;

            ResourceChangedCount?.Invoke(_transform.childCount);
        }

        private void Catch(Transform item, Rigidbody rigidbody)
        {
            if (Vector3.Distance(item.position, _transform.position) <= _catchDistance)
            {
                item.parent = _transform;
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