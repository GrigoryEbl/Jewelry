using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SetterFork : MonoBehaviour
{
    [SerializeField] private GameObject _forkRust;
    [SerializeField] private GameObject _forkSilver;
    [SerializeField] private GameObject _forkGold;

    private int _levelToSilverFork = 5;
    private int _levelToGoldFork = 10;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    public void ChangeFork(int cargoLevel)
    {
        if (cargoLevel == _levelToSilverFork)
        {
            _forkRust.SetActive(false);
            _forkSilver.SetActive(true);
            SaveData();
        }

        if (cargoLevel == _levelToGoldFork)
        {
           _forkSilver.SetActive(false);
            _forkGold.SetActive(true);
            SaveData();
        }
    }

    private void SaveData()
    {
        YandexGame.savesData.IsRustForkActive = _forkRust.activeSelf;
        YandexGame.savesData.IsSilverForkActive = _forkSilver.activeSelf;
        YandexGame.savesData.IsGoldForkActive = _forkGold.activeSelf;
        YandexGame.SaveProgress();
    }

    private void GetLoad()
    {
        _forkRust.SetActive(YandexGame.savesData.IsRustForkActive);
        _forkSilver.SetActive(YandexGame.savesData.IsSilverForkActive);
        _forkGold.SetActive(YandexGame.savesData.IsGoldForkActive);
    }
}
