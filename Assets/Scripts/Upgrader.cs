using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private Player _player;
    [SerializeField] private UpgraderView _upgraderView;

    private readonly int _maxLevel = 50;

    private float _multiplier = 1.07f;
    private float _basePrice = 30;

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
        PriceUpgradeEngine = _basePrice;
        PriceUpgradeMagnet = _basePrice;
        PriceUpgradeCargo = _basePrice;
    }

    public void UpgradeEngine()
    {
        if (_car.EngineLevel < _maxLevel && _player.Wallet.Money >= PriceUpgradeEngine)
        {
            Pay(PriceUpgradeEngine);
            _car.IncreaseLevelEngine();
            PriceUpgradeEngine = CalculateModifyPrice(_car.EngineLevel);
        }
    }

    public void UpgradeMagnet()
    {
        if (_car.MagnetLevel < _maxLevel && _player.Wallet.Money >= PriceUpgradeMagnet)
        {
            Pay(PriceUpgradeMagnet);
            _car.IncreaseLevelMagnet();
            PriceUpgradeMagnet = CalculateModifyPrice(_car.MagnetLevel);
        }
    }

    public void UpgradeCargo()
    {
        if (_car.CargoLevel < _maxLevel && _player.Wallet.Money >= PriceUpgradeCargo)
        {
            Pay(PriceUpgradeCargo);
            _car.IncreaseLevelCargo();
            PriceUpgradeCargo = CalculateModifyPrice(_car.CargoLevel);
        }
    }

    private float CalculateModifyPrice(int degree)
    {
        return _basePrice * Mathf.Pow(_multiplier, degree);
    }

    private void Pay(float price)
    {
        _player.Wallet.TryDecreaseMoney((uint)price);
    }
}
