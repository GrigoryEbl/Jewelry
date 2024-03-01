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

    private int _maxCargoCount;
    private Attractor _attractor;
    private Transform _transform;
    private int _attractedResources;
    private float _startCatchDistance = 0.4f;

    public int Level { get; private set; }
    public int MaxCargoCount => _maxCargoCount;

    private void Awake()
    {
        _transform = transform;
        _attractor = GetComponent<Attractor>();
    }

    public void Init()
    {
        Level = YandexGame.savesData.MagnetLevel;
        _maxCargoCount = YandexGame.savesData.CargoLevel;
        print("magnet init");
    }

    public void ChangeMaxCargoCount()
    {
        _maxCargoCount++;
    }

    public void ChangeLevel(int level)
    {
        Level = level;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent == _transform)
            return;

        if (_transform.childCount >= _maxCargoCount)
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
            resource.transform.parent = _transform;
            rigidbody.isKinematic = true;
            _attractedResources = _transform.childCount;
            AddCathDistance();
        }
    }

    private void AddCathDistance()
    {
        _catchDistance += 0.05f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _catchDistance);
    }
}
