using Domain.Player;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Barrier
{
    [RequireComponent(typeof(BoxCollider))]
    public class BarrierInterection : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Transform _barrier;
        [SerializeField] private int _price;
        [SerializeField] private ParticleSystem _explosion;

        private BoxCollider _boxCollider;

        public event UnityAction<bool> BarrierReached;
        public event UnityAction NewZoneOpened;

        public int Price => _price;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                BarrierReached?.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                BarrierReached?.Invoke(false);
            }
        }

        public void SetActive(bool isActive)
        {
            _barrier.gameObject.SetActive(isActive);
            _boxCollider.enabled = isActive;
        }

        public void OpenNewZone()
        {
            if (_player.Wallet.TryDecreaseMoney((uint)Price))
            {
                _explosion.Play();
                _barrier.gameObject.SetActive(false);
                _boxCollider.enabled = false;
                NewZoneOpened?.Invoke();
            }
        }

        public bool GetActiveInfo()
        {
            return _barrier.gameObject.activeSelf;
        }
    }
}