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
        private const string _magnetName = "Magnet";
        private const string _wheelsName = "Wheels";
        private const string _capacityName = "Capacity";
        private readonly int _maxLevel = 30;

        [SerializeField] private PlayerCar _car;
        [SerializeField] private Player _player;

        [SerializeField] private IImprovable _improvable;

        private float _multiplier = 1.3f;
        private float _basePrice = 30;
        private float _addedPowerEngine = 0.26f;

        private int _levelToUpMultiplier = 10;
        private float _multiplierExtra = 0.03f;

        public event Action<bool> UpgradeZoneReached;
        public event Action<float, int> MagnetCharacteristiscsChanged;
        public event Action<float, int> WheelsCharacteristiscsChanged;
        public event Action<float, int> CapacityCharacteristiscsChanged;

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
                MagnetCharacteristiscsChanged?.Invoke(PriceUpgradeMagnet, _car.MagnetLevel);
                WheelsCharacteristiscsChanged?.Invoke(PriceUpgradeWheels, _car.WheelsLevel);
                CapacityCharacteristiscsChanged?.Invoke(PriceUpgradeCapacity, _car.CapacityLevel);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                UpgradeZoneReached?.Invoke(false);
            }
        }

        public void Upgrade(string detailName)
        {
            switch (detailName)
            {
                case _magnetName:
                    if (TryUpgrade(_car.MagnetLevel, PriceUpgradeMagnet))
                    {
                        _car.IncreaseLevelDetail(detailName);
                        PriceUpgradeMagnet = CalculateModifyPrice(_car.MagnetLevel);
                        MagnetCharacteristiscsChanged?.Invoke(PriceUpgradeMagnet, _car.MagnetLevel);
                    }
                    break;

                case _wheelsName:
                    if (TryUpgrade(_car.WheelsLevel, PriceUpgradeWheels))
                    {
                        _car.IncreaseLevelDetail(detailName);
                        PriceUpgradeWheels = CalculateModifyPrice(_car.WheelsLevel);
                        WheelsCharacteristiscsChanged?.Invoke(PriceUpgradeWheels, _car.WheelsLevel);
                    }
                    break;

                case _capacityName:
                    if (TryUpgrade(_car.CapacityLevel, PriceUpgradeCapacity))
                    {
                        _car.IncreaseLevelDetail(detailName);
                        PriceUpgradeCapacity = CalculateModifyPrice(_car.CapacityLevel);
                        CapacityCharacteristiscsChanged?.Invoke(PriceUpgradeCapacity, _car.CapacityLevel);
                    }
                    break;
            }

            SaveData();
        }

        private bool TryUpgrade(int detailLevel, float price)
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