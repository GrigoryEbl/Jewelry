using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SetterWheels : MonoBehaviour
{
    [SerializeField] private GameObject _lowWheels;
    [SerializeField] private GameObject _middleWheels;
    [SerializeField] private GameObject _highWheels;

    private int _levelToMiddleWheels = 15;
    private int _levelToHighWheels = 25;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    public void ChangeWheels(int engineLevel)
    {
        if (engineLevel == _levelToMiddleWheels)
        {
           _lowWheels.SetActive(false);
            _middleWheels.SetActive(true);
            SaveData();
        }

        if (engineLevel == _levelToHighWheels)
        {
            _middleWheels.SetActive(false);
            _highWheels.SetActive(true);
            SaveData();
        }
    }

    private void SaveData()
    {
        YandexGame.savesData.IsLowWheelsActive = _lowWheels.activeSelf;
        YandexGame.savesData.IsMiddleWheelsActive = _middleWheels.activeSelf;
        YandexGame.savesData.IsHighWheelsActive = _highWheels.activeSelf;
        YandexGame.SaveProgress();
    }

    private void GetLoad()
    {
        _lowWheels.SetActive(YandexGame.savesData.IsLowWheelsActive);
        _middleWheels.SetActive(YandexGame.savesData.IsMiddleWheelsActive);
        _highWheels.SetActive(YandexGame.savesData.IsHighWheelsActive);
    }
}
