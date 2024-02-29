using System;
using UnityEngine;
using YG;

public class Wallet : MonoBehaviour
{
    private uint _money;
    public uint Money => _money;

    public event Action<uint> MoneyChanched;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    public void TakeMoney(uint money)
    {
        _money += money;
        MoneyChanched?.Invoke(_money);
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

    private void GetLoad()
    {
        _money = YandexGame.savesData.Money;
    }
}
