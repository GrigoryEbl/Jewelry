using System;
using UnityEngine;
using YG;

public class Upgrader : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private Player _player;

    [SerializeField] private float _multiplier;
    [SerializeField] private float _basePrice = 30;
    [SerializeField] private float _addedPowerEngine = 0.20f;

    private readonly int _maxLevel = 30;

    public int MaxLevel => _maxLevel;
    private int _levelToUpMultiplier = 10;
    private float _multiplierExtra = 0.03f;

    public event Action<bool> UpgradeZoneReach;
    public event Action CharacteristiscsChange;

    public float PriceUpgradeWheels { get; private set; }
    public float PriceUpgradeMagnet { get; private set; }
    public float PriceUpgradeCapacity { get; private set; }

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
        if (_car.WheelsLevel < _maxLevel && _player.TryToPay(PriceUpgradeWheels))
        {
            Pay(PriceUpgradeWheels);
            _car.IncreaseLevelWheels(_addedPowerEngine);
            PriceUpgradeWheels = CalculateModifyPrice(_car.WheelsLevel);
            CharacteristiscsChange?.Invoke();
            SaveData();
        }
    }

    public void UpgradeMagnet()
    {
        if (_car.MagnetLevel < _maxLevel && _player.TryToPay(PriceUpgradeMagnet))
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
        if (_car.CapacityLevel < _maxLevel && _player.TryToPay(PriceUpgradeCapacity))
        {
            Pay(PriceUpgradeCapacity);
            _car.IncreaseLevelCapacity();
            PriceUpgradeCapacity = CalculateModifyPrice(_car.CapacityLevel);
            CharacteristiscsChange?.Invoke();
            SaveData();
        }
    }

    private float CalculateModifyPrice(int degree)
    {
        if (degree >= _levelToUpMultiplier)
            return _basePrice * Mathf.Pow(_multiplier + _multiplierExtra, degree);

        return _basePrice * Mathf.Pow(_multiplier, degree);
    }

    private void Pay(float price)
    {
        _player.Wallet.TryDecreaseMoney((uint)price);
    }

    private void GetData()
    {
        PriceUpgradeWheels = YandexGame.savesData.PriceUpgradeEngine;
        PriceUpgradeMagnet = YandexGame.savesData.PriceUpgradeMagnet;
        PriceUpgradeCapacity = YandexGame.savesData.PriceUpgradeCargo;
    }

    private void SaveData()
    {
        YandexGame.savesData.PriceUpgradeEngine = PriceUpgradeWheels;
        YandexGame.savesData.PriceUpgradeMagnet = PriceUpgradeMagnet;
        YandexGame.savesData.PriceUpgradeCargo = PriceUpgradeCapacity;
        YandexGame.SaveProgress();
    }
}
