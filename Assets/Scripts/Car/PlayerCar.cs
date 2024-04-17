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
        [SerializeField] private Capacity _capacity;

        [SerializeField] private DetailChanger _capacityChanger;
        [SerializeField] private DetailChanger _wheelsChanger;
        [SerializeField] private DetailChanger _magnetChanger;

        public int WheelsLevel { get; private set; }
        public int MagnetLevel { get; private set; }
        public int CapacityLevel { get; private set; }

        private void OnEnable() => YandexGame.GetDataEvent += OnGetData;

        private void OnDisable() => YandexGame.GetDataEvent -= OnGetData;

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
                    CapacityLevel++;
                    _capacity.Upgrade();
                    _magnetChanger.Change(MagnetLevel);
                    _capacityChanger.Change(CapacityLevel);
                    SaveData();
                    break;
            }
        }

        private void OnGetData()
        {
            _wheels.Init();
            _magnet.Init();
            _capacity.Init();

            MagnetLevel = _magnet.Level;
            WheelsLevel = _wheels.Level;
            CapacityLevel = _capacity.Level;
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