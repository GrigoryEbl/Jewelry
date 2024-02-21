using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private uint _money;
    public uint Money => _money;

    public event Action<uint> MoneyChanched;

    public void TakeMoney(uint money)
    {
        _money += money * 10000;
        MoneyChanched?.Invoke(_money);
    }

    public void TryDecreaseMoney(uint money)
    {
        if (_money >= money)
        {
            _money -= money;
            MoneyChanched?.Invoke(_money);
        }
        else
        {
            throw new ArgumentException("недостаточно денег");
        }

    }
}
