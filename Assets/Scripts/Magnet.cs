using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minCatchDistance;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent == transform)
            return;

        if (other.TryGetComponent(out Resource resource) && resource.TryGetComponent(out Rigidbody rigidbody))
        {
            print(resource.name);

            Vector3 direction = transform.position - resource.transform.position;
            rigidbody.velocity = direction * _speed * Time.deltaTime;

            if (Vector3.Distance(resource.transform.position, transform.position) <= _minCatchDistance)
            {
                Catch(resource, rigidbody);
            }
        }
    }

    public void Catch(Resource resource, Rigidbody rigidbody)
    {
        if (resource != null)
        {
            resource.transform.parent = transform;
            rigidbody.isKinematic = true;
        }
    }
}
