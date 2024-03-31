using UnityEngine;
using YG;

[RequireComponent(typeof(SetterHand))]
[RequireComponent(typeof(SetterWheels))]
[RequireComponent(typeof(SetterMagnet))]
public class Car : MonoBehaviour
{
    [SerializeField] private Movement _wheels;
    [SerializeField] private Magnet _magnet;
    [SerializeField] private Transform _startPosition;

    private SetterHand _setterCapacity;
    private SetterWheels _setterWheels;
    private SetterMagnet _setterMagnet;

    public int WheelsLevel { get; private set; }
    public int MagnetLevel { get; private set; }
    public int CapacityLevel { get; private set; }

    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    private void Awake()
    {
        _setterCapacity = GetComponent<SetterHand>();
        _setterWheels = GetComponent<SetterWheels>();
        _setterMagnet = GetComponent<SetterMagnet>();
    }

    public void IncreaseLevelWheels(float addedSpeedWheels)
    {
        WheelsLevel++;
        _wheels.Upgrade(addedSpeedWheels);
        _setterWheels.TryChangeWheels(WheelsLevel);
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

    public void SetStartPosition()
    {
        transform.position = _startPosition.position;
    }

    private void GetData()
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
