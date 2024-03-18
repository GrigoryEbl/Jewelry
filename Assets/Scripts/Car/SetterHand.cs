using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SetterHand : MonoBehaviour
{
    [SerializeField] private GameObject _lowHand;
    [SerializeField] private GameObject _middleHand;
    [SerializeField] private GameObject _highHand;

    [SerializeField] private int _levelToMiddleCapacity = 15;
    [SerializeField] private int _levelToHighCapacity = 25;

    public int LevelToMiddleCapacity => _levelToMiddleCapacity;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    public void ChangeHand(int capacityLevel)
    {
        if (capacityLevel == _levelToMiddleCapacity)
        {
            _lowHand.SetActive(false);
            _middleHand.SetActive(true);
            SaveData();
        }

        if (capacityLevel == _levelToHighCapacity)
        {
           _middleHand.SetActive(false);
            _highHand.SetActive(true);
            SaveData();
        }
    }

    private void SaveData()
    {
        YandexGame.savesData.IsLowHandActive = _lowHand.activeSelf;
        YandexGame.savesData.IsMiddleHandActive = _middleHand.activeSelf;
        YandexGame.savesData.IsHighHandActive = _highHand.activeSelf;
        YandexGame.SaveProgress();
    }

    private void GetLoad()
    {
        _lowHand.SetActive(YandexGame.savesData.IsLowHandActive);
        _middleHand.SetActive(YandexGame.savesData.IsMiddleHandActive);
        _highHand.SetActive(YandexGame.savesData.IsHighHandActive);
    }
}
