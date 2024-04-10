using Item;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CollectedItem _itemPrefab;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private int _maxSpawnCount;
    [SerializeField] private float _spawnDelay;

    private Transform _transform;
    private int _spawnedCount;

    public CollectedItem Item => _itemPrefab;

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

            if (_spawnedCount < _maxSpawnCount + 1)
            {
                yield return new WaitForSeconds(_spawnDelay);
                Vector2 randomPosition = Random.insideUnitCircle * _spawnRadius;

                Instantiate(_itemPrefab, new Vector3(_transform.position.x + randomPosition.x, _transform.position.y, _transform.position.z + randomPosition.y), Quaternion.identity, _transform);
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
