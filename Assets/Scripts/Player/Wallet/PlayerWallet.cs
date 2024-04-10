using System;
using UnityEngine;
using YG;

namespace Wallet
{
    public class PlayerWallet : MonoBehaviour
    {
        [SerializeField] private uint _money;

        private int _recordMoney;

        public event Action<uint> MoneyChanched;
        public event Action<uint> MoneyAdded;

        public uint Money => _money;

        private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

        private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

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

        public bool TryDecreaseMoney(uint price)
        {
            if (_money >= price)
            {
                _money -= price;
                MoneyChanched?.Invoke(_money);
                YandexGame.savesData.Money = _money;
                YandexGame.SaveProgress();
                return true;
            }
            else
            {
                throw new ArgumentException("Not enough money");
            }
        }

        private void GetLoad()
        {
            _money = YandexGame.savesData.Money;
            MoneyChanched?.Invoke(_money);
        }
    }
}