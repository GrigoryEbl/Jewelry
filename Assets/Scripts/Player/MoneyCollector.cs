using System;
using UnityEngine;

[RequireComponent(typeof(Attractor))]
public class MoneyCollector : MonoBehaviour
{
    [SerializeField] private float _force = 400f;
    [SerializeField] private float _minCatchDistance = 2f;

    private Attractor _attractor;
    private Transform _transform;

    public event Action<uint> MoneyCatched;

    private void Awake()
    {
        _transform = transform;
        _attractor = GetComponent<Attractor>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Money money))
        {
           _attractor.Attract(money.transform,transform, _force, false);

            if (Vector3.Distance(money.transform.position, _transform.position) <= _minCatchDistance)
            {
                MoneyCatched?.Invoke(money.Value);
                Destroy(money.gameObject);
            }
        }
    }
}
