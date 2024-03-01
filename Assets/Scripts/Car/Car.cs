using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Car : MonoBehaviour
{
    [SerializeField] private Movement _engine;
    [SerializeField] private Magnet _magnet;

    public int EngineLevel { get; private set; }
    public int MagnetLevel { get; private set; }
    public int CargoLevel { get; private set; }

    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    public void IncreaseLevelEngine(float addedPowerEngine)
    {
        EngineLevel++;
        _engine.Ugrade(addedPowerEngine);
        SaveData();
    }

    public void IncreaseLevelMagnet()
    {
        MagnetLevel++;
        _magnet.ChangeLevel(MagnetLevel);
        SaveData();
    }

    public void IncreaseLevelCargo()
    {
        CargoLevel++;
        _magnet.ChangeMaxCargoCount();
        SaveData();
    }

    private void GetData()
    {
        _engine.Init();
        _magnet.Init();

        MagnetLevel = _magnet.Level;
        EngineLevel = _engine.Level;
        CargoLevel = _magnet.MaxCargoCount;
    }

    private void SaveData()
    {
        YandexGame.savesData.EngineLevel = EngineLevel;
        YandexGame.savesData.EngineSpeed = _engine.Speed;
        YandexGame.savesData.MagnetLevel = MagnetLevel;
        YandexGame.savesData.CargoLevel = CargoLevel;
        YandexGame.SaveProgress();
    }
}
