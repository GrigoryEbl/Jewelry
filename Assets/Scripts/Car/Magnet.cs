using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class Magnet : MonoBehaviour, IAttractor
{
    [SerializeField] private float _force;
    [SerializeField] private float _catchDistance;
    [SerializeField] private int _maxCargoCount;

    private int _attractedResources;
    private float _startCatchDistance = 0.4f;

    public int Level { get; private set; }
    public int CargoLevel => _maxCargoCount;

    private void Awake()
    {
        Level = 1;
        _maxCargoCount = 1;
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.name);

        if (other.transform.parent == transform)
            return;

        if (transform.childCount >= _maxCargoCount)
            return;

        if (transform.childCount < _attractedResources)
            _catchDistance = _startCatchDistance;

        if (other.TryGetComponent(out Resource resource) && resource.TryGetComponent(out Rigidbody rigidbody))
        {
            if (Level < resource.Level)
                return;

            Vector3 direction = transform.position - resource.transform.position;

            Attract(direction, rigidbody, _force);
            TryCatch(resource, rigidbody);
        }
    }

    private void TryCatch(Resource resource, Rigidbody rigidbody)
    {
        if (Vector3.Distance(resource.transform.position, transform.position) <= _catchDistance)
        {
            resource.transform.parent = transform;
            rigidbody.isKinematic = true;
            _attractedResources = transform.childCount;
            AddCathDistance();
        }
    }

    public void Attract(Vector3 direction, Rigidbody rigidbody, float force)
    {
        rigidbody.velocity = direction * force * Time.deltaTime;
    }

    public void ChangeMaxCargoCount()
    {
        _maxCargoCount++;
    }

    public void ChangeLevel(int level)
    {
        Level = level;
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
