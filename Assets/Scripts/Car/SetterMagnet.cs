using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SetterMagnet : MonoBehaviour
{
    [SerializeField] private GameObject _lowMagnet;
    [SerializeField] private GameObject _lowMagnetHighChain;

    [SerializeField] private GameObject _middleMagnetHighChain;
    [SerializeField] private GameObject _middleMagnet;

    [SerializeField] private GameObject _highMagnetLowChain;
    [SerializeField] private GameObject _highMagnet;

    private int _levelToMiddleMagnet = 5;
    private int _levelToHighMagnet = 10;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    public void ChangeMagnet(int magnetLevel, int cargoLevel)
    {
        if (magnetLevel < _levelToMiddleMagnet && cargoLevel >= _levelToHighMagnet)
        {
            _lowMagnet.SetActive(false);
            _lowMagnetHighChain.SetActive(true);
        }

        if (magnetLevel == Mathf.Clamp(magnetLevel, _levelToMiddleMagnet, _levelToHighMagnet - 1) && cargoLevel < _levelToHighMagnet)
        {
            _lowMagnet.SetActive(false);
            _lowMagnetHighChain.SetActive(false);
            _middleMagnet.SetActive(true);
        }
        else if (magnetLevel == Mathf.Clamp(magnetLevel, _levelToMiddleMagnet, _levelToHighMagnet - 1) && cargoLevel >= _levelToHighMagnet)
        {
            _lowMagnet.SetActive(false);
            _lowMagnetHighChain.SetActive(false);
            _middleMagnet.SetActive(false);
            _middleMagnetHighChain.SetActive(true);
        }

        if (magnetLevel >= _levelToHighMagnet && cargoLevel < _levelToHighMagnet)
        {
            _middleMagnetHighChain.SetActive(false);
            _middleMagnet.SetActive(false);
            _highMagnetLowChain.SetActive(true);
        }
        else if (magnetLevel >= _levelToHighMagnet && cargoLevel >= _levelToHighMagnet)
        {
            _middleMagnetHighChain.SetActive(false);
            _middleMagnet.SetActive(false);
            _highMagnetLowChain.SetActive(false);
            _highMagnet.SetActive(true);
        }

        SaveData();
    }

    private void SaveData()
    {
        YandexGame.savesData.IsLowMagnegActive = _lowMagnet.activeSelf;
        YandexGame.savesData.IslowMagnetHighChainActive = _lowMagnetHighChain.activeSelf;

        YandexGame.savesData.IsMiddleMagnetActive = _middleMagnet.activeSelf;
        YandexGame.savesData.IsMiddleMagnetHighChainActive = _middleMagnetHighChain.activeSelf;

        YandexGame.savesData.IsHighMagnetActive = _highMagnet.activeSelf;
        YandexGame.savesData.IsHighMagnetLowChainActive = _highMagnetLowChain.activeSelf;
        YandexGame.SaveProgress();
    }

    private void GetLoad()
    {
        _lowMagnet.SetActive(YandexGame.savesData.IsLowMagnegActive);
        _lowMagnetHighChain.SetActive(YandexGame.savesData.IslowMagnetHighChainActive);

        _middleMagnet.SetActive(YandexGame.savesData.IsMiddleMagnetActive);
        _middleMagnetHighChain.SetActive(YandexGame.savesData.IsMiddleMagnetHighChainActive);

        _highMagnet.SetActive(YandexGame.savesData.IsHighMagnetActive);
        _highMagnetLowChain.SetActive(YandexGame.savesData.IsHighMagnetLowChainActive);
    }
}
