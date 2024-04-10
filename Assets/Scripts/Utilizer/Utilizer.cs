using Item;
using Sounds;
using UnityEngine;
using Wallet;

namespace Utilize
{
    [RequireComponent(typeof(Attractor))]
    public class Utilizer : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private float _minCatchDistance;
        [SerializeField] private Transform _utilizePoint;
        [SerializeField] private Money _moneyPrefab;
        [SerializeField] private Transform _spawnMoneyPoint;
        [SerializeField] private MoneyStacker _moneyStacker;
        [SerializeField] private PlayerEffect _playerEffect;

        private Attractor _attractor;
        private bool _isCatch;

        private void Awake()
        {
            _attractor = GetComponent<Attractor>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out CollectedItem item) && item.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.isKinematic = false;
                _attractor.Attract(item.transform, _utilizePoint, _force);
                Catch(item);
            }
        }

        private void Catch(CollectedItem item)
        {
            if (Vector3.Distance(item.transform.position, _utilizePoint.transform.position) <= _minCatchDistance)
            {
                uint priceResource = item.Price;
                Destroy(item.gameObject);
                var newMoney = Instantiate(_moneyPrefab, _spawnMoneyPoint.position, Quaternion.identity, null);
                newMoney.SetValue(priceResource);
                _moneyStacker.Stacking(newMoney.transform);
                _isCatch = true;
            }

            if (_isCatch)
            {
                _playerEffect.Play();
                _isCatch = false;
            }
        }
    }
}
