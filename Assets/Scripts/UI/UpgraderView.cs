using System;
using TMPro;
using UnityEngine;

public class UpgraderView : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _text;
    [SerializeField] private Car _car;
    [SerializeField] private Upgrader _upgrader;
    [SerializeField] private GameObject _upgradeScreen;

    public event Action<bool> OpenPanel;

    private void Update()
    {
        _text[0].text = "Engine level: " + _car.EngineLevel.ToString();
        _text[1].text = "$" + _upgrader.PriceUpgradeEngine.ToString("F1");

        _text[2].text = "Magnet level: " + _car.MagnetLevel.ToString();
        _text[3].text = "$" + _upgrader.PriceUpgradeMagnet.ToString("F1");

        _text[4].text = "Cargo level: " + _car.CargoLevel.ToString();
        _text[5].text = "$" + _upgrader.PriceUpgradeCargo.ToString("F1");
    }

    public void ShowScreen(bool isActive)
    {
        _upgradeScreen.SetActive(isActive);
        OpenPanel?.Invoke(isActive);
    }
}
