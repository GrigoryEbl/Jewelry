using System;
using UnityEngine;

public class MoneyCollector : MonoBehaviour, IAttractor
{
    [SerializeField] private float _force = 400f;
    [SerializeField] private float _minCatchDistance = 2f;

    public event Action<uint> MoneyCatched;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Money money) && other.TryGetComponent(out Rigidbody rigidbody))
        {
            Vector3 direction = transform.position - money.transform.position;

            Attract(direction, rigidbody, _force);

            if (Vector3.Distance(money.transform.position, transform.position) <= _minCatchDistance)
            {
                MoneyCatched?.Invoke(money.Value);
                Destroy(money.gameObject);
            }
        }
    }

    public void Attract(Vector3 direction, Rigidbody rigidbody, float force)
    {
        rigidbody.velocity = direction * force * Time.deltaTime;
    }
}
