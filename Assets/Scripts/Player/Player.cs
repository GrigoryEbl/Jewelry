using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private MoneyCollector _playerInterection;

    public event Action<bool, BarrierInterection> BarrierInterectionReach;

    public Wallet Wallet => _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _playerInterection = GetComponent<MoneyCollector>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            _wallet.TakeMoney(100000);      //DELETE
        }
    }

    private void OnEnable() => _playerInterection.MoneyCatched += OnMoneyCatch;

    private void OnDisable() => _playerInterection.MoneyCatched -= OnMoneyCatch;

    private void OnMoneyCatch(uint value)
    {
        _wallet.TakeMoney(value);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out BarrierInterection barrierInterection))
        {
            BarrierInterectionReach?.Invoke(true, barrierInterection);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out BarrierInterection barrierInterection))
        {
            BarrierInterectionReach?.Invoke(false, barrierInterection);
        }
    }
}
