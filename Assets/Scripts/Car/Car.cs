using UnityEngine;
using YG;

namespace PlayerCar
{
    [RequireComponent(typeof(HandChanger))]
    [RequireComponent(typeof(WheelsChanger))]
    [RequireComponent(typeof(MagnetChanger))]
    public class Car : MonoBehaviour
    {
        [SerializeField] private Movement _wheels;
        [SerializeField] private Magnet _magnet;
        [SerializeField] private Transform _startPosition;

        private HandChanger _setterCapacity;
        private WheelsChanger _setterWheels;
        private MagnetChanger _setterMagnet;

        public int WheelsLevel { get; private set; }
        public int MagnetLevel { get; private set; }
        public int CapacityLevel { get; private set; }

        private void OnEnable() => YandexGame.GetDataEvent += OnGetData;

        private void OnDisable() => YandexGame.GetDataEvent -= OnGetData;

        private void Awake()
        {
            _setterCapacity = GetComponent<HandChanger>();
            _setterWheels = GetComponent<WheelsChanger>();
            _setterMagnet = GetComponent<MagnetChanger>();
        }

        public void IncreaseLevelWheels(float addedSpeedWheels)
        {
            WheelsLevel++;
            _wheels.Upgrade(addedSpeedWheels);
            _setterWheels.ChangeWheels(WheelsLevel);
            SaveData();
        }

        public void IncreaseLevelMagnet()
        {
            MagnetLevel++;
            _magnet.ChangeLevel(MagnetLevel);
            _setterMagnet.ChangeMagnet(MagnetLevel, CapacityLevel);
            SaveData();
        }

        public void IncreaseLevelCapacity()
        {
            int addedCapacity = 1;
            CapacityLevel++;
            _magnet.ChangeMaxCapacityCount(addedCapacity);
            _setterMagnet.ChangeMagnet(MagnetLevel, CapacityLevel);
            _setterCapacity.ChangeHand(CapacityLevel);
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