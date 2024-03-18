using System.Collections;
using System.Diagnostics;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgraderView : MonoBehaviour
{
    [SerializeField] private Upgrader _upgrader;
    [SerializeField] private GameObject _upgradeScreen;
    [SerializeField] private Car _car;
    [SerializeField] private float _speedSlider;


    [Header("Magnet")]
    [SerializeField] private TMP_Text _magnetPriceText;
    [SerializeField] private TMP_Text _magnetLevelText;
    [SerializeField] private Slider _sliderMagnet;
    [SerializeField] private SetterMagnet _setterMagnet;
    [SerializeField] private Image _imageMiddleMagnet;
    [SerializeField] private Image _imageHighMagnet;

    [Header("Wheels")]
    [SerializeField] private TMP_Text _enginePriceText;
    [SerializeField] private TMP_Text _engineLevelText;
    [SerializeField] private Slider _sliderWheels;
    [SerializeField] private SetterWheels _setterWheels;
    [SerializeField] private Image _imageMiddleWheel;
    [SerializeField] private Image _imageHighWheel;

    [Header("Capacity")]
    [SerializeField] private TMP_Text _capacityPriceText;
    [SerializeField] private TMP_Text _capacityLevelText;
    [SerializeField] private Slider _sliderCapacity;
    [SerializeField] private SetterHand _setterFork;
    [SerializeField] private Image _imageMiddleFork;
    [SerializeField] private Image _imageHighFork;

    private void Awake()
    {
        OnChangeMagnet();
        OnChangeWheels();
        OnChangeCapacity();
    }

    private void OnEnable()
    {
        _upgrader.UpgradeZoneReach += OnUpgradeZoneReach;
        _upgrader.CharacteristiscsChange += OnChangeMagnet;
        _upgrader.CharacteristiscsChange += OnChangeWheels;
        _upgrader.CharacteristiscsChange += OnChangeCapacity;
    }

    private void OnDisable()
    {
        _upgrader.UpgradeZoneReach -= OnUpgradeZoneReach;
        _upgrader.CharacteristiscsChange -= OnChangeMagnet;
        _upgrader.CharacteristiscsChange -= OnChangeWheels;
        _upgrader.CharacteristiscsChange -= OnChangeCapacity;
    }

    private void OnUpgradeZoneReach(bool isActive)
    {
        _upgradeScreen.SetActive(isActive);
        OnChangeMagnet();
        OnChangeWheels();
        OnChangeCapacity();
    }

    private void OnChangeMagnet()
    {
        ChangeText(_magnetPriceText, _upgrader.PriceUpgradeMagnet, _magnetLevelText, _car.MagnetLevel, "Magnet");
        StartCoroutine(Slide(_sliderMagnet, _car.MagnetLevel));
        SetImageDetail(_car.MagnetLevel, _setterMagnet.LevelToMiddleMagnet, _imageMiddleMagnet, _imageHighMagnet);
    }

    private void OnChangeWheels()
    {
        ChangeText(_enginePriceText, _upgrader.PriceUpgradeWheels, _engineLevelText, _car.WheelsLevel, "Wheels");
        StartCoroutine(Slide(_sliderWheels, _car.WheelsLevel));
        SetImageDetail(_car.WheelsLevel, _setterFork.LevelToMiddleCapacity, _imageMiddleWheel, _imageHighWheel);
    }

    private void OnChangeCapacity()
    {
        ChangeText(_capacityPriceText, _upgrader.PriceUpgradeCapacity, _capacityLevelText, _car.CapacityLevel, "Capacity");
        StartCoroutine(Slide(_sliderCapacity, _car.CapacityLevel));
        SetImageDetail(_car.CapacityLevel, _setterFork.LevelToMiddleCapacity, _imageMiddleFork, _imageHighFork);
    }

    private void ChangeText(TMP_Text price, float priceInfo, TMP_Text level, int levelInfo, string nameDetail)
    {
        price.text = $"${priceInfo.ToString("F0")}";
        level.text = $"{nameDetail}: {levelInfo}";
    }

    private void SetImageDetail(int levelinfo, int levelToMiddleDetail, Image middleDetail, Image highDetail)
    {
        if (levelinfo >= levelToMiddleDetail)
        {
            middleDetail.gameObject.SetActive(false);
            highDetail.gameObject.SetActive(true);
        }
    }

    private IEnumerator Slide(Slider slider, int target)
    {
        while (slider.value != target)
        {
            slider.value = Mathf.MoveTowards(slider.value, target, _speedSlider * Time.deltaTime);
            yield return null;
        }
    }

}
