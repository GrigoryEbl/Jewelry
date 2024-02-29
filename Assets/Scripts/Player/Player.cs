using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Player : MonoBehaviour
{
    [SerializeField] private JoystickInput _joystickInput;
    [SerializeField] private InputPC _inputPC;

    private Wallet _wallet;
    private MoneyCollector _moneyCollector;

    public Wallet Wallet => _wallet;

    private void Awake()
    {
        if(YandexGame.EnvironmentData.isMobile)
        {
            _joystickInput.SetWorkInput(true);
            _inputPC.SetWorkInput(false);
        }
        else if(YandexGame.EnvironmentData.isDesktop)
        {
            _joystickInput.SetWorkInput(false);
            _inputPC.SetWorkInput(true);
        }

        _wallet = GetComponent<Wallet>();
        _moneyCollector = GetComponent<MoneyCollector>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            _wallet.TakeMoney(100000);      //DELETE
        }
    }

    private void OnEnable() => _moneyCollector.MoneyCatched += OnMoneyCatch;

    private void OnDisable() => _moneyCollector.MoneyCatched -= OnMoneyCatch;

    private void OnMoneyCatch(uint value)
    {
        _wallet.TakeMoney(value);
    }
}
