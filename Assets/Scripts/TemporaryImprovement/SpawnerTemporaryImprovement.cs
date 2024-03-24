using UnityEngine;

public class SpawnerTemporaryImprovement : MonoBehaviour
{
    [SerializeField] private TemporaryImprovement _temporaryImprovementPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Timer _timer;
    [SerializeField] private float _spawnDelay;

    private void OnEnable() => _timer.TimeEmpty += Spawn;
    private void OnDisable() => _timer.TimeEmpty -= Spawn;

    private void Awake()
    {
        _timer.StartCoroutine(_timer.Work(_spawnDelay));
    }

    public void Spawn()
    {
        var newTemporaryImprovement = Instantiate(_temporaryImprovementPrefab, SelectSpawnPoint(),Quaternion.identity);
        _timer.StartCoroutine(_timer.Work(_spawnDelay));
    }

    private Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        return spawnPoint;
    }
}
