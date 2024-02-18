using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private PlayerInterection _playerInterection;

    public Wallet Wallet => _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _playerInterection = GetComponent<PlayerInterection>();
    }

    private void OnEnable() => _playerInterection.MoneyCatched += OnMoneyCatch;

    private void OnDisable() => _playerInterection.MoneyCatched -= OnMoneyCatch;

    private void OnMoneyCatch(uint value)
    {
        _wallet.TakeMoney(value);
    }

}
