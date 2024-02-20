using UnityEngine;

public class Magnet : MonoBehaviour, IAttractor
{
    [SerializeField] private float _force;
    [SerializeField] private float _minCatchDistance;

    private int _maxCargoCount = 1;
    private int _attractedResources;

    public int Level { get; private set; }

    private void Awake()
    {
        Level = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent == transform)
            return;

        if (transform.childCount >= _maxCargoCount)
            return;

        if (other.TryGetComponent(out Resource resource) && resource.TryGetComponent(out Rigidbody rigidbody))
        {
            if (Level >= resource.Level)
            {
                Vector3 direction = transform.position - resource.transform.position;

                if (_attractedResources < _maxCargoCount)
                {
                    Attract(direction, rigidbody, _force);
                }

                TryCatch(resource, rigidbody);
            }
        }
    }

    private void TryCatch(Resource resource, Rigidbody rigidbody)
    {
        if (Vector3.Distance(resource.transform.position, transform.position) <= _minCatchDistance)
        {
            resource.transform.parent = transform;
            rigidbody.isKinematic = true;
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
}
