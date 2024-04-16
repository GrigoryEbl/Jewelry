using UnityEngine;
using YG;
using Assets.Scripts.Car.Details;

namespace Assets.Scripts.Car
{
    public class PlayerCar : MonoBehaviour
    {
        private const string _magnetName = "Magnet";
        private const string _wheelsName = "Wheels";
        private const string _capacityName = "Capacity";

        [SerializeField] private Movement _wheels;
        [SerializeField] private Magnet _magnet;

        [SerializeField] private DetailChanger _capacityChanger;
        [SerializeField] private DetailChanger _wheelsChanger;
        [SerializeField] private DetailChanger _magnetChanger;

        private string[] _details = new string[3];

        public int WheelsLevel { get; private set; }
        public int MagnetLevel { get; private set; }
        public int CapacityLevel { get; private set; }

        private void OnEnable() => YandexGame.GetDataEvent += OnGetData;

        private void OnDisable() => YandexGame.GetDataEvent -= OnGetData;

        private void Awake()
        {
            _details[0] = _magnetName;
            _details[1] = _wheelsName;
            _details[2] = _capacityName;
        }

        public void IncreaseLevelDetail(string detail)
        {
            switch (detail)
            {
                case _magnetName:
                    MagnetLevel++;
                    _magnet.ChangeLevel(MagnetLevel);
                    _magnetChanger.ChangeMagnet(MagnetLevel, CapacityLevel);
                    SaveData();
                    break;

                case _wheelsName:
                    float addedSpeedWheels = 0.26f;
                    WheelsLevel++;
                    _wheels.Upgrade(addedSpeedWheels);
                    _wheelsChanger.Change(WheelsLevel);
                    SaveData();
                    break;

                case _capacityName:
                    int addedCapacity = 1;
                    CapacityLevel++;
                    _magnet.ChangeMaxCapacityCount(addedCapacity);
                    _magnetChanger.Change(MagnetLevel);
                    _capacityChanger.Change(CapacityLevel);
                    SaveData();
                    break;
            }
        }

        public void IncreaseLevelWheels(float addedSpeedWheels)
        {
            WheelsLevel++;
            _wheels.Upgrade(addedSpeedWheels);
            _wheelsChanger.Change(WheelsLevel);
            SaveData();
        }

        public void IncreaseLevelMagnet()
        {
            MagnetLevel++;
            _magnet.ChangeLevel(MagnetLevel);
            _magnetChanger.ChangeMagnet(MagnetLevel, CapacityLevel);
            SaveData();
        }

        public void IncreaseLevelCapacity()
        {
            int addedCapacity = 1;
            CapacityLevel++;
            _magnet.ChangeMaxCapacityCount(addedCapacity);
            _magnetChanger.Change(MagnetLevel);
            _capacityChanger.Change(CapacityLevel);
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