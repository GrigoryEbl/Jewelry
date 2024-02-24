using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Resource _resourcePrefab;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private int _maxSpawnCount;
    [SerializeField] private float _spawnDelay;

    private Transform _transform;
    private int _spawnedCount;

    private void Start()
    {
        _transform = transform;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            _spawnedCount = transform.childCount;

            if (_spawnedCount < _maxSpawnCount)
            {
                yield return new WaitForSeconds(_spawnDelay);
                Vector2 RandomPosition = Random.insideUnitCircle * _spawnRadius;

                Instantiate(_resourcePrefab, new Vector3(_transform.position.x + RandomPosition.x, transform.position.y, _transform.position.z + RandomPosition.y), Quaternion.identity, _transform);
            }

            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
    }
}
