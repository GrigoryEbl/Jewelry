using Sounds;
using UnityEngine;
using YG;

namespace Assets.Scripts.Car.Details
{
    public class HandChanger : MonoBehaviour
    {
        [SerializeField] private GameObject _lowHand;
        [SerializeField] private GameObject _middleHand;
        [SerializeField] private GameObject _highHand;

        [SerializeField] private int _levelToMiddleCapacity = 15;
        [SerializeField] private int _levelToHighCapacity = 25;

        [SerializeField] private PlayerEffect _playerEffect;

        public int LevelToMiddleCapacity => _levelToMiddleCapacity;

        private void OnEnable() => YandexGame.GetDataEvent += OnGetLoad;

        private void OnDisable() => YandexGame.GetDataEvent -= OnGetLoad;

        public void ChangeHand(int capacityLevel)
        {
            if (capacityLevel == _levelToMiddleCapacity)
            {
                _lowHand.SetActive(false);
                _middleHand.SetActive(true);
                SaveData();
                _playerEffect.Play();
            }

            if (capacityLevel == _levelToHighCapacity)
            {
                _middleHand.SetActive(false);
                _highHand.SetActive(true);
                SaveData();
                _playerEffect.Play();
            }
        }

        private void SaveData()
        {
            YandexGame.savesData.IsLowHandActive = _lowHand.activeSelf;
            YandexGame.savesData.IsMiddleHandActive = _middleHand.activeSelf;
            YandexGame.savesData.IsHighHandActive = _highHand.activeSelf;
            YandexGame.SaveProgress();
        }

        private void OnGetLoad()
        {
            _lowHand.SetActive(YandexGame.savesData.IsLowHandActive);
            _middleHand.SetActive(YandexGame.savesData.IsMiddleHandActive);
            _highHand.SetActive(YandexGame.savesData.IsHighHandActive);
        }
    }
}
