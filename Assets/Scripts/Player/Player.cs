using PlayerInput;
using UnityEngine;
using Wallet;

namespace Domain.Player
{
    [RequireComponent(typeof(PlayerWallet))]
    [RequireComponent(typeof(MoneyCollector))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private JoystickInput _joystickInput;

        private PlayerWallet _wallet;
        private MoneyCollector _moneyCollector;

        public PlayerWallet Wallet => _wallet;

        private void Awake()
        {
            _wallet = GetComponent<PlayerWallet>();
            _moneyCollector = GetComponent<MoneyCollector>();
        }

        private void OnEnable() => _moneyCollector.MoneyCatched += OnMoneyCatch;

        private void OnDisable() => _moneyCollector.MoneyCatched -= OnMoneyCatch;

        private void OnMoneyCatch(uint value)
        {
            _wallet.TakeMoney(value);
        }
    }
}
