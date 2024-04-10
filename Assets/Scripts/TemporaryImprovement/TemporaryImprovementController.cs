using Domain.Player;
using PlayerCar;
using UnityEngine;
using UnityEngine.Events;

namespace TemporaryImprovement
{
    public class TemporaryImprovementController : MonoBehaviour
    {
        private const string _magnet = "Magnet";
        private const string _wheels = "Wheels";
        private const string _capacity = "Capacity";

        [SerializeField] private float _timeImprovement = 60;
        [SerializeField] private float _lifeTime;
        [SerializeField] private Timer _timerImprovement;
        [SerializeField] private Timer _timerLifeTime;

        private Magnet _magnetCar;
        private Magnet _capacityCar;
        private Movement _wheelsCar;

        private string[] _details = new string[3];
        private int _upgradeValue = 3;

        public UnityAction<bool> ObjectReached;
        public UnityAction Improved;

        public string[] Details => _details;
        public bool IsImprovment { get; private set; }
        public string NameUpgradeDetail { get; private set; }

        private void Awake()
        {
            _magnetCar = FindObjectOfType<Magnet>();
            _capacityCar = FindObjectOfType<Magnet>();
            _wheelsCar = FindObjectOfType<Movement>();

            _details[0] = _magnet;
            _details[1] = _wheels;
            _details[2] = _capacity;

            SelectDetail();
            _timerLifeTime.StartCoroutine(_timerLifeTime.Work(_lifeTime));
        }

        private void OnEnable()
        {
            _timerImprovement.TimeEmpty += Downgrade;
            _timerLifeTime.TimeEmpty += DestorySelf;
        }

        private void OnDisable()
        {
            _timerImprovement.TimeEmpty -= Downgrade;
            _timerLifeTime.TimeEmpty -= DestorySelf;
        }

        private void Update()
        {
            if (IsImprovment == true)
                _timerLifeTime.StopAllCoroutines();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                ObjectReached?.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                ObjectReached?.Invoke(false);
            }
        }

        public void Upgrade()
        {
            switch (NameUpgradeDetail)
            {
                case _magnet:
                    _magnetCar.ChangeLevel(_magnetCar.Level + _upgradeValue);
                    break;

                case _wheels:
                    _wheelsCar.Upgrade(_upgradeValue);
                    break;

                case _capacity:
                    _capacityCar.ChangeMaxCapacityCount(_upgradeValue);
                    break;
            }

            IsImprovment = true;
            _timerImprovement.StartCoroutine(_timerImprovement.Work(_timeImprovement));
            Improved?.Invoke();
        }

        private void Downgrade()
        {
            switch (NameUpgradeDetail)
            {
                case _magnet:
                    _magnetCar.ChangeLevel(_magnetCar.Level - _upgradeValue);
                    break;

                case _wheels:
                    _wheelsCar.Upgrade(-_upgradeValue);
                    break;

                case _capacity:
                    _capacityCar.ChangeMaxCapacityCount(-_upgradeValue);
                    break;
            }

            DestorySelf();
        }

        private void SelectDetail()
        {
            NameUpgradeDetail = _details[Random.Range(0, _details.Length)];
        }

        private void DestorySelf()
        {
            Destroy(gameObject);
        }
    }
}
