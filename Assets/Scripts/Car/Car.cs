using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Car : MonoBehaviour
{
    [SerializeField] private Movement _engine;
    [SerializeField] private Magnet _magnet;

    private float _addedPowerEngine = 0.20f;

    public int EngineLevel { get; private set; }
    public int MagnetLevel { get; private set; }
    public int CargoLevel { get; private set; }

    private void Start()
    {
        EngineLevel = 1;
        MagnetLevel = _magnet.Level;
        CargoLevel = _magnet.CargoLevel;
    }
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GetLoad()
    {
        EngineLevel = YandexGame.savesData.EngineLevel;
        MagnetLevel = YandexGame.savesData.MagnetLevel;
        CargoLevel = YandexGame.savesData.CargoLevel;
    }

    public void IncreaseLevelEngine()
    {
        EngineLevel++;
        _engine.ChangeSpeed(_addedPowerEngine);
        Save();
    }

    public void IncreaseLevelMagnet()
    {
        MagnetLevel++;
        _magnet.ChangeLevel(MagnetLevel);
        Save();
    }

    public void IncreaseLevelCargo()
    {
        CargoLevel++;
        _magnet.ChangeMaxCargoCount();
        Save();
    }

    private void Save()
    {
        YandexGame.savesData.EngineLevel = EngineLevel;
        YandexGame.savesData.MagnetLevel = MagnetLevel;
        YandexGame.savesData.CargoLevel = CargoLevel;
        YandexGame.SaveProgress();
    }
}
