using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilizer : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _minCatchDistance;
    [SerializeField] private Transform _utilizePoint;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Resource resource) && resource.TryGetComponent(out Rigidbody rigidbody))
        {
            print(resource.name);
            rigidbody.isKinematic = false;
            Vector3 direction = _utilizePoint.transform.position - resource.transform.position;
            rigidbody.velocity = direction * _speed * Time.deltaTime;

            if (Vector3.Distance(resource.transform.position, _utilizePoint.transform.position) <= _minCatchDistance)
            {
               Destroy(resource.gameObject);
            }
        }
    }
}
