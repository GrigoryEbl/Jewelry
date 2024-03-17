using System;
using UnityEngine;
using YG;

public class Wallet : MonoBehaviour
{
    private uint _money;
    private int _recordMoney;

    public uint Money => _money;

    public event Action<uint> MoneyChanched;
    public event Action<uint> MoneyAdded;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            _money = 0;     //DELETE
        }
    }

    public void TakeMoney(uint addedMoney)
    {
        _money += addedMoney;
        _recordMoney += (int)addedMoney;
        YandexGame.NewLeaderboardScores("Money", _recordMoney);
        
        MoneyChanched?.Invoke(_money);
        MoneyAdded?.Invoke(addedMoney);
        YandexGame.savesData.Money = _money;
        YandexGame.SaveProgress();

    }

    public bool TryDecreaseMoney(uint money)
    {
        if (_money >= money)
        {
            _money -= money;
            MoneyChanched?.Invoke(_money);
            YandexGame.savesData.Money = _money;
            YandexGame.SaveProgress();
            return true;
        }
        else
        {
            throw new ArgumentException("недостаточно денег");
        }
    }

    public void ResetRecord()
    {
        _recordMoney = 0;
        YandexGame.NewLeaderboardScores("Money", _recordMoney);
    }

    private void GetLoad()
    {
        _money = YandexGame.savesData.Money;
        MoneyChanched?.Invoke(_money);
    }
}
