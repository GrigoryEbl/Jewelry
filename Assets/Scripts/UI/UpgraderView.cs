using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UpgraderView : MonoBehaviour
{
    [SerializeField] private Upgrader _upgrader;
    [SerializeField] private GameObject _upgradeScreen;
    [SerializeField] private Car _car;
    [SerializeField] private float _speedSlider;

    [SerializeField] private TMP_Text _enginePriceText;
    [SerializeField] private TMP_Text _engineLevelText;

    [SerializeField] private TMP_Text _magnetPriceText;
    [SerializeField] private TMP_Text _magnetLevelText;
    [SerializeField] private Slider _slider;

    [SerializeField] private TMP_Text _cargoPriceText;
    [SerializeField] private TMP_Text _cargoLevelText;

    private void OnEnable()
    {
        _upgrader.UpgradeZoneReach += OnUpgradeZoneReach;
        _upgrader.CharacteristiscsChange += OnChangeMagnet;
        _upgrader.CharacteristiscsChange += OnChangeEngine;
        _upgrader.CharacteristiscsChange += OnChangeCargo;
    }
    private void OnDisable()
    {
        _upgrader.UpgradeZoneReach -= OnUpgradeZoneReach;
        _upgrader.CharacteristiscsChange -= OnChangeMagnet;
        _upgrader.CharacteristiscsChange -= OnChangeEngine;
        _upgrader.CharacteristiscsChange -= OnChangeCargo;
    }

    private void OnUpgradeZoneReach(bool isActive)
    {
        _upgradeScreen.SetActive(isActive);
        OnChangeMagnet();
        OnChangeEngine();
        OnChangeCargo();
    }

    private void OnChangeMagnet()
    {
        _magnetPriceText.text = $"${_upgrader.PriceUpgradeMagnet.ToString("F0")}";
        _magnetLevelText.text = $"Magnet level: {_car.MagnetLevel}";
        StartCoroutine(Slide(_car.MagnetLevel));
    }

    private void OnChangeEngine()
    {
        _enginePriceText.text = $"${_upgrader.PriceUpgradeEngine.ToString("F0")}";
        _engineLevelText.text = $"Engine level: {_car.EngineLevel}";
    }

    private void OnChangeCargo()
    {
        _cargoPriceText.text = $"${_upgrader.PriceUpgradeCargo.ToString("F0")}";
        _cargoLevelText.text = $"Cargo level: {_car.CargoLevel}";
    }

    private IEnumerator Slide(int target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _speedSlider * Time.deltaTime);
            yield return null;
        }
    }
}
