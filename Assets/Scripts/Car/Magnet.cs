using System;
using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using YG;

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
        if (other.TryGetComponent(out Utilizer utilizer))
            return;

        if (other.transform.parent == _transform)
            return;

        if (_transform.childCount >= _maxCapacityCount)
            return;

        if (_transform.childCount == 0)
            _catchDistance = _startCatchDistance;

        if (other.TryGetComponent(out Resource resource) && resource.TryGetComponent(out Rigidbody rigidbody))
        {
            if (Level < resource.Level)
                return;

            _attractor.Attract(resource.transform, _transform, _force, false);
            TryCatch(resource, rigidbody);
        }
    }

    private void TryCatch(Resource resource, Rigidbody rigidbody)
    {
        if (Vector3.Distance(resource.transform.position, _transform.position) <= _catchDistance)
        {
            _playerEffect.Play();
            resource.transform.parent = _transform;
            rigidbody.isKinematic = true;
            AddCathDistance();
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
