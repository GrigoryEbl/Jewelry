using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
   [SerializeField] private Wallet _wallet;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _wallet.MoneyChanched += OnMoneyChange;
    }

    private void OnDisable()
    {
        _wallet.MoneyChanched -= OnMoneyChange;
    }

    private void OnMoneyChange(uint money)
    {
        _text.text = "$" + money.ToString();
    }

}
