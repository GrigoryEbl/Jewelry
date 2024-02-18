using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilizer : MonoBehaviour, IAttractor
{
    [SerializeField] private float _force;
    [SerializeField] private float _minCatchDistance;
    [SerializeField] private Transform _utilizePoint;
    [SerializeField] private Money _moneyPrefab;
    [SerializeField] private Transform _spawnMoneyPoint;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Resource resource) && resource.TryGetComponent(out Rigidbody rigidbody))
        {
            uint priceResource = resource.Price;
            Vector3 direction = _utilizePoint.transform.position - resource.transform.position;

            rigidbody.isKinematic = false;

            Attract(direction, rigidbody, _force);

            if (Vector3.Distance(resource.transform.position, _utilizePoint.transform.position) <= _minCatchDistance)
            {
                Destroy(resource.gameObject);
                Instantiate(_moneyPrefab, _spawnMoneyPoint.position, Quaternion.identity, null).SetValue(priceResource);
            }
        }
    }

    public void Attract(Vector3 direction, Rigidbody rigidbody, float force)
    {
        rigidbody.velocity = direction * force * Time.deltaTime;
    }
}
