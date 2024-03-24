using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SetterMagnet : MonoBehaviour
{
    [SerializeField] private GameObject _lowMagnet;
    [SerializeField] private GameObject _lowMagnetLongChain;

    [SerializeField] private GameObject _middleMagnetLongChain;
    [SerializeField] private GameObject _middleMagnet;

    [SerializeField] private GameObject _highMagnetShortChain;
    [SerializeField] private GameObject _highMagnet;

    [SerializeField] private int _levelToMiddleMagnet = 15;
    [SerializeField] private int _levelToHighMagnet = 25;

    [SerializeField] private PlayerEffect _playerEffect;

    public int LevelToMiddleMagnet => _levelToMiddleMagnet;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    public void ChangeMagnet(int magnetLevel, int capacityLevel)
    {
        if (magnetLevel < _levelToMiddleMagnet && capacityLevel >= _levelToHighMagnet)
        {
            _lowMagnet.SetActive(false);
            _lowMagnetLongChain.SetActive(true);
        }

        if (magnetLevel == Mathf.Clamp(magnetLevel, _levelToMiddleMagnet, _levelToHighMagnet - 1) && capacityLevel < _levelToHighMagnet)
        {
            _lowMagnet.SetActive(false);
            _lowMagnetLongChain.SetActive(false);
            _middleMagnet.SetActive(true);
        }
        else if (magnetLevel == Mathf.Clamp(magnetLevel, _levelToMiddleMagnet, _levelToHighMagnet - 1) && capacityLevel >= _levelToHighMagnet)
        {
            _lowMagnet.SetActive(false);
            _lowMagnetLongChain.SetActive(false);
            _middleMagnet.SetActive(false);
            _middleMagnetLongChain.SetActive(true);
        }

        if (magnetLevel >= _levelToHighMagnet && capacityLevel < _levelToHighMagnet)
        {
            _middleMagnetLongChain.SetActive(false);
            _middleMagnet.SetActive(false);
            _highMagnetShortChain.SetActive(true);
        }
        else if (magnetLevel >= _levelToHighMagnet && capacityLevel >= _levelToHighMagnet)
        {
            _middleMagnetLongChain.SetActive(false);
            _middleMagnet.SetActive(false);
            _highMagnetShortChain.SetActive(false);
            _highMagnet.SetActive(true);
        }

        if(magnetLevel == _levelToMiddleMagnet || magnetLevel == _levelToHighMagnet)
            _playerEffect.Play();

        SaveData();
    }

    private void SaveData()
    {
        YandexGame.savesData.IsLowMagnegActive = _lowMagnet.activeSelf;
        YandexGame.savesData.IslowMagnetLongChainActive = _lowMagnetLongChain.activeSelf;

        YandexGame.savesData.IsMiddleMagnetActive = _middleMagnet.activeSelf;
        YandexGame.savesData.IsMiddleMagnetLongChainActive = _middleMagnetLongChain.activeSelf;

        YandexGame.savesData.IsHighMagnetActive = _highMagnet.activeSelf;
        YandexGame.savesData.IsHighMagnetShortChainActive = _highMagnetShortChain.activeSelf;
        YandexGame.SaveProgress();
    }

    private void GetLoad()
    {
        _lowMagnet.SetActive(YandexGame.savesData.IsLowMagnegActive);
        _lowMagnetLongChain.SetActive(YandexGame.savesData.IslowMagnetLongChainActive);

        _middleMagnet.SetActive(YandexGame.savesData.IsMiddleMagnetActive);
        _middleMagnetLongChain.SetActive(YandexGame.savesData.IsMiddleMagnetLongChainActive);

        _highMagnet.SetActive(YandexGame.savesData.IsHighMagnetActive);
        _highMagnetShortChain.SetActive(YandexGame.savesData.IsHighMagnetShortChainActive);
    }
}
