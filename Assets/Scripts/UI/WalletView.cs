using TMPro;
using UnityEngine;
using Assets.Scripts.Wallet;

namespace Assets.Scripts.UI
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private GameObject _addedMoneyTextPrefab;
        [SerializeField] private PlayerWallet _wallet;
        [SerializeField] private TMP_Text _text;

        private void OnEnable()
        {
            _wallet.MoneyChanched += OnMoneyChange;
            _wallet.MoneyAdded += OnAddMoney;
        }

        private void OnDisable()
        {
            _wallet.MoneyChanched -= OnMoneyChange;
            _wallet.MoneyAdded -= OnAddMoney;
        }

        private void OnMoneyChange(uint value)
        {
            _text.text = "$" + value.ToString();
        }

        private void OnAddMoney(uint addedMoney)
        {
            if (_addedMoneyTextPrefab.TryGetComponent(out TMP_Text text))
            {
                text.text = "+" + addedMoney.ToString();
                Instantiate(_addedMoneyTextPrefab, _text.transform);
            }
        }
    }
} 