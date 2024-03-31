using UnityEngine;

public class ResourcePositionSaver : MonoBehaviour
{
    private Transform _transform;
    private float _returnedDistance = 10f;
    private float _startTime = 30f;
    private float _time = 30f;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
            TryReturnResource();
    }

    private void TryReturnResource()
    {
        for (int i = 0; i < _transform.childCount; i++)
        {
            if (Vector3.Distance(_transform.GetChild(i).position, _transform.position) >= _returnedDistance)
            {
                _transform.GetChild(i).position = _transform.position;
            }
        }

        _time = _startTime;
    }
}
