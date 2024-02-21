using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierInterection : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _barrier;
    [SerializeField] private BarrierInterectionView _barrierInterectionView;
    [SerializeField] private int _price;

    public int Price => _price; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _barrierInterectionView.ShowScreen(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _barrierInterectionView.ShowScreen(false);
        }
    }

    private void OnDestroy()
    {
        _barrierInterectionView.ShowScreen(false);
    }

    private void Pay(float price)
    {
        _player.Wallet.TryDecreaseMoney((uint)price);
    }

    public void OpenNewZone()
    {
        if (_player.Wallet.Money >= Price)
        {
            Pay(Price);
            Destroy(_barrier.gameObject);
            Destroy(gameObject);
        }
    }
}
