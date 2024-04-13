using UnityEngine;
using YG;
using Assets.Scripts.Car.Details;

namespace Assets.Scripts.Car
{
    public class PlayerCar : MonoBehaviour
    {
        [SerializeField] private Movement _wheels;
        [SerializeField] private Magnet _magnet;
        [SerializeField] private Transform _startPosition;

        [SerializeField] private DetailChanger _setterCapacity;
        [SerializeField] private DetailChanger _setterWheels;
        [SerializeField] private DetailChanger _setterMagnet;

        public int WheelsLevel { get; private set; }
        public int MagnetLevel { get; private set; }
        public int CapacityLevel { get; private set; }

        private void OnEnable() => YandexGame.GetDataEvent += OnGetData;

        private void OnDisable() => YandexGame.GetDataEvent -= OnGetData;

        public void IncreaseLevelWheels(float addedSpeedWheels)
        {
            WheelsLevel++;
            _wheels.Upgrade(addedSpeedWheels);
            _setterWheels.Change(WheelsLevel,0);
            SaveData();
        }

        public void IncreaseLevelMagnet()
        {
            MagnetLevel++;
            _magnet.ChangeLevel(MagnetLevel);
            _setterMagnet.Change(MagnetLevel, CapacityLevel);
            SaveData();
        }

        public void IncreaseLevelCapacity()
        {
            int addedCapacity = 1;
            CapacityLevel++;
            _magnet.ChangeMaxCapacityCount(addedCapacity);
            _setterMagnet.Change(MagnetLevel, CapacityLevel);
            _setterCapacity.Change(CapacityLevel, CapacityLevel);
            SaveData();
        }

        private void OnGetData()
        {
            _wheels.Init();
            _magnet.Init();

            MagnetLevel = _magnet.Level;
            WheelsLevel = _wheels.Level;
            CapacityLevel = _magnet.MaxCapacityCount;
        }

        private void SaveData()
        {
            YandexGame.savesData.EngineLevel = WheelsLevel;
            YandexGame.savesData.EngineSpeed = _wheels.Speed;
            YandexGame.savesData.MagnetLevel = MagnetLevel;
            YandexGame.savesData.CapacityLevel = CapacityLevel;
            YandexGame.SaveProgress();
        }
    }
}