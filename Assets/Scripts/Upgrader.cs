using Domain.Player;
using Assets.Scripts.Car;
using System;
using UnityEngine;
using YG;
using Assets.Scripts.Car.Details;

namespace Assets.Scripts
{
    public class Upgrader : MonoBehaviour
    {
        private readonly int _maxLevel = 30;

        [SerializeField] private PlayerCar _car;
        [SerializeField] private Player _player;
        [SerializeField] private IImprovable _improvable;

        private float _multiplier;
        private float _basePrice = 30;
        private float _addedPowerEngine = 0.26f;

        private int _levelToUpMultiplier = 10;
        private float _multiplierExtra = 0.03f;

        public event Action<bool> UpgradeZoneReached;
        public event Action<int, int> CharacteristiscsChanged;

        public int MaxLevel => _maxLevel;
        public float PriceUpgradeWheels { get; private set; }
        public float PriceUpgradeMagnet { get; private set; }
        public float PriceUpgradeCapacity { get; private set; }

        private void OnEnable() => YandexGame.GetDataEvent += GetData;

        private void OnDisable() => YandexGame.GetDataEvent -= GetData;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                UpgradeZoneReached?.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                UpgradeZoneReached?.Invoke(false);
            }
        }

        public void UpgradeWheels()
        {
            if (_car.WheelsLevel < _maxLevel && _player.Wallet.TryDecreaseMoney((uint)PriceUpgradeWheels))
            {
                _car.IncreaseLevelWheels(_addedPowerEngine);
                PriceUpgradeWheels = CalculateModifyPrice(_car.WheelsLevel);
                CharacteristiscsChanged?.Invoke((int)PriceUpgradeWheels, _car.WheelsLevel);
                SaveData();
            }
        }

        public void UpgradeMagnet()
        {
            if (TryUpgrade(_car.MagnetLevel, (uint)PriceUpgradeMagnet))
            {
                _car.IncreaseLevelMagnet();
                PriceUpgradeMagnet = CalculateModifyPrice(_car.MagnetLevel);
                CharacteristiscsChanged?.Invoke((int)PriceUpgradeMagnet, _car.MagnetLevel);
                SaveData();
            }
        }

        public void UpgradeCapacity()
        {
            if (TryUpgrade(_car.CapacityLevel, (uint)PriceUpgradeCapacity))
            {
                _car.IncreaseLevelCapacity();
                PriceUpgradeCapacity = CalculateModifyPrice(_car.CapacityLevel);
                CharacteristiscsChanged?.Invoke((int)PriceUpgradeCapacity, _car.CapacityLevel);
                SaveData();
            }
        }

        private bool TryUpgrade(int detailLevel, uint price)
        {
            if (detailLevel < _maxLevel && _player.Wallet.TryDecreaseMoney((uint)price))
                return true;

            return false;
        }

        private float CalculateModifyPrice(int degree)
        {
            if (degree >= _levelToUpMultiplier)
                return _basePrice * Mathf.Pow(_multiplier + _multiplierExtra, degree);

            return _basePrice * Mathf.Pow(_multiplier, degree);
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
}