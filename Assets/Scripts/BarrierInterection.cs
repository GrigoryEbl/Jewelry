using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class BarrierInterection : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _barrier;
    [SerializeField] private int _price;

    public event UnityAction<bool> BarrierReach;
    public int Price => _price;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            BarrierReach?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            BarrierReach?.Invoke(false);
        }
    }

    public void TryOpenNewZone()
    {
        if (_player.Wallet.TryDecreaseMoney((uint)Price))
        {
            _barrier.gameObject.SetActive(false);
        }
    }
}
