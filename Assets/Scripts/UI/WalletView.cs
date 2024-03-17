using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private GameObject _addedMoneyTextPrefab;
    [SerializeField] private Wallet _wallet;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

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

    private void OnMoneyChange(uint money)
    {
        _text.text = "$" + money.ToString();
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
