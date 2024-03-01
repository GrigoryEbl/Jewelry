using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Upgrader : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private Player _player;

    private readonly int _maxLevel = 50;
    private readonly int _maxLevelCargo = 30;

    private float _addedPowerEngine = 0.20f;
    private float _multiplier = 2.1f;
    private float _basePrice = 30;

    public event Action<bool> UpgradeZoneReach;
    public event Action CharacteristiscsChange;

    public float PriceUpgradeEngine { get; private set; }
    public float PriceUpgradeMagnet { get; private set; }
    public float PriceUpgradeCargo { get; private set; }

    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            UpgradeZoneReach?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            UpgradeZoneReach?.Invoke(false);
        }
    }

    public void UpgradeEngine()
    {
        if (_car.EngineLevel < _maxLevel && _player.Wallet.Money >= PriceUpgradeEngine)
        {
            Pay(PriceUpgradeEngine);
            _car.IncreaseLevelEngine(_addedPowerEngine);
            PriceUpgradeEngine = CalculateModifyPrice(_car.EngineLevel);
            CharacteristiscsChange?.Invoke();
            SaveData();
        }
    }

    public void UpgradeMagnet()
    {
        if (_car.MagnetLevel < _maxLevel && _player.Wallet.Money >= PriceUpgradeMagnet)
        {
            Pay(PriceUpgradeMagnet);
            _car.IncreaseLevelMagnet();
            PriceUpgradeMagnet = CalculateModifyPrice(_car.MagnetLevel);
            CharacteristiscsChange?.Invoke();
            SaveData();
        }
    }

    public void UpgradeCargo()
    {
        if (_car.CargoLevel < _maxLevelCargo && _player.Wallet.Money >= PriceUpgradeCargo)
        {
            Pay(PriceUpgradeCargo);
            _car.IncreaseLevelCargo();
            PriceUpgradeCargo = CalculateModifyPrice(_car.CargoLevel);
            CharacteristiscsChange?.Invoke();
            SaveData();
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

    private void GetData()
    {
        PriceUpgradeEngine = YandexGame.savesData.PriceUpgradeEngine;
        PriceUpgradeMagnet = YandexGame.savesData.PriceUpgradeMagnet;
        PriceUpgradeCargo = YandexGame.savesData.PriceUpgradeCargo;
    }

    private void SaveData()
    {
        YandexGame.savesData.PriceUpgradeEngine = PriceUpgradeEngine;
        YandexGame.savesData.PriceUpgradeMagnet = PriceUpgradeMagnet;
        YandexGame.savesData.PriceUpgradeCargo = PriceUpgradeCargo;
        YandexGame.SaveProgress();
    }
}
