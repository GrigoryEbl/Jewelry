using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierInterection : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _barrier;
    [SerializeField] private int _price;

    public int Price => _price;

    public void OpenNewZone()
    {
        if (_player.Wallet.Money >= Price)
        {
            Pay(Price);
            Destroy(_barrier.gameObject);
            Destroy(gameObject);
        }
    }

    private void Pay(float price)
    {
        _player.Wallet.TryDecreaseMoney((uint)price);
    } 
}
