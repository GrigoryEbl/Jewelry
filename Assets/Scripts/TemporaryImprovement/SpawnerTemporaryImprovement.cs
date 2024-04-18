using UnityEngine;

namespace Assets.Scripts.TemporaryImprovement
{
    [RequireComponent(typeof(Timer))]
    public class SpawnerTemporaryImprovement : MonoBehaviour
    {
        [SerializeField] private TemporaryImprovementController _temporaryImprovementPrefab;
        [SerializeField] private Transform _points;

        private Transform[] _spawnPoints;
        private Timer _timer;
        private float _spawnDelay = 120f;

        private void OnEnable() => _timer.TimeEmpty += Spawn;
        private void OnDisable() => _timer.TimeEmpty -= Spawn;

        private void Awake()
        {
            _timer = GetComponent<Timer>();
            _spawnPoints = new Transform[_points.childCount];
            _timer.StartCoroutine(_timer.Work(_spawnDelay));
            SetSpawnPoints();
        }

        public void Spawn()
        {
            var newTemporaryImprovement = Instantiate(_temporaryImprovementPrefab, SelectSpawnPoint(), Quaternion.identity);
            _timer.StartCoroutine(_timer.Work(_spawnDelay));
        }

        private Vector3 SelectSpawnPoint()
        {
            Vector3 spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            return spawnPoint;
        }

        private void SetSpawnPoints()
        {
            for (int i = 0; i < _points.childCount; i++)
            {
                _spawnPoints[i] = _points.GetChild(i).transform;
            }
        }
    }
}