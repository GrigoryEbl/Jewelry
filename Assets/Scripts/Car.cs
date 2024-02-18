using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Movement _engine;
    [SerializeField] private Magnet _magnet;

    public int EngineLevel { get; private set; }
    public int MagnetLevel { get; private set; }
    public int CargoLevel { get; private set; }

    private void Start()
    {
        EngineLevel = 1;
        MagnetLevel = 1;
        CargoLevel = 1;
    }

    public void IncreaseLevelEngine()
    {
        EngineLevel++;
        _engine.ChangeSpeed(0.15f);
    }

    public void IncreaseLevelMagnet()
    {
        MagnetLevel++;
        _magnet.ChangeLevel(MagnetLevel);
    }

    public void IncreaseLevelCargo()
    {
        CargoLevel++;
        _magnet.ChangeMaxCargoCount();
    }
}
