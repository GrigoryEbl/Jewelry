using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Attractor))]
public class Utilizer : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _minCatchDistance;
    [SerializeField] private Transform _utilizePoint;
    [SerializeField] private Money _moneyPrefab;
    [SerializeField] private Transform _spawnMoneyPoint;
    [SerializeField] private MoneyStacker _moneyStacker;

    private Attractor _attractor;

    private void Awake()
    {
        _attractor = GetComponent<Attractor>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Resource resource) && resource.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;

            _attractor.Attract(resource.transform, _utilizePoint, _force, true);
            TryCatch(resource);
        }
    }

    private void TryCatch(Resource resource)
    {
        if (Vector3.Distance(resource.transform.position, _utilizePoint.transform.position) <= _minCatchDistance)
        {
            uint priceResource = resource.Price;
            Destroy(resource.gameObject);
            var newMoney = Instantiate(_moneyPrefab, _spawnMoneyPoint.position, Quaternion.identity, null);
                newMoney.SetValue(priceResource);
            _moneyStacker.Stacking(newMoney.transform);
        }
    }
}
