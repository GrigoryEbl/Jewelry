using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private Player _player;
    [SerializeField] private UpgraderView _upgraderView;

    private readonly int _maxLevel = 50;

    public float PriceUpgradeEngine { get; private set; }
    public float PriceUpgradeMagnet { get; private set; }
    public float PriceUpgradeCargo { get; private set; }

    private void Start()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            print(other.name);
            _upgraderView.ShowScreen(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _upgraderView.ShowScreen(false);
        }
    }

    private void Init()
    {
        PriceUpgradeEngine = 10;
        PriceUpgradeMagnet = 10;
        PriceUpgradeCargo = 10;
    }

    public void UpgradeEngine()
    {
        if (_car.EngineLevel < _maxLevel && _player.Wallet.Money >= PriceUpgradeEngine)
        {
            _player.Wallet.TryDecreaseMoney((uint)PriceUpgradeEngine);
            _car.IncreaseLevelEngine();
            PriceUpgradeEngine *= 2;
        }
    }

    public void UpgradeMagnet()
    {
        if (_car.MagnetLevel < _maxLevel && _player.Wallet.Money >= PriceUpgradeMagnet)
        {
            _player.Wallet.TryDecreaseMoney((uint)PriceUpgradeMagnet);
            _car.IncreaseLevelMagnet();
            PriceUpgradeMagnet *= 2;
        }
    }

    public void UpgradeCargo()
    {
        if (_car.CargoLevel < _maxLevel && _player.Wallet.Money >= PriceUpgradeCargo)
        {
            _player.Wallet.TryDecreaseMoney((uint)PriceUpgradeCargo);
            _car.IncreaseLevelCargo();
            PriceUpgradeCargo *= 2;
        }
    }
}
