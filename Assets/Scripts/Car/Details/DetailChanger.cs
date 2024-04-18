using Assets.Scripts.Sounds;
using System;
using UnityEngine;

namespace Assets.Scripts.Car.Details
{
    public class DetailChanger : MonoBehaviour
    {
        private const int _levelToMiddleDetail = 15;
        private const int _levelToHighDetail = 25;

        [SerializeField] private GameObject _lowDetail;
        [SerializeField] private GameObject _lowDetailModifyVariant;

        [SerializeField] private GameObject _middleDetail;
        [SerializeField] private GameObject _middleDetailModifyVariant;

        [SerializeField] private GameObject _highDetail;
        [SerializeField] private GameObject _highDetailModifyVariant;

        [SerializeField] private PlayerEffect _playerEffect;

        public event Action DetailChanged;

        public int LevelToMiddleDetail => _levelToMiddleDetail;

        private void Awake()
        {
            _lowDetail.SetActive(true);
        }

        public void ChangeMagnet(int level, int capacityLevel)
        {
            if (level < _levelToMiddleDetail && capacityLevel >= _levelToHighDetail && _lowDetailModifyVariant != null)
            {
                _lowDetail.SetActive(false);
                _lowDetailModifyVariant.SetActive(true);
            }

            if (level == Mathf.Clamp(level, _levelToMiddleDetail, _levelToHighDetail - 1) && capacityLevel < _levelToHighDetail)
            {
                _lowDetail.SetActive(false);
                _lowDetailModifyVariant.SetActive(false);
                _middleDetail.SetActive(true);
            }
            else if (level == Mathf.Clamp(level, _levelToMiddleDetail, _levelToHighDetail - 1) && capacityLevel >= _levelToHighDetail && _middleDetailModifyVariant != null)
            {
                _lowDetail.SetActive(false);
                _lowDetailModifyVariant.SetActive(false);
                _middleDetail.SetActive(false);
                _middleDetailModifyVariant.SetActive(true);
            }

            if (level >= _levelToHighDetail && capacityLevel < _levelToHighDetail && _highDetailModifyVariant != null)
            {
                _middleDetailModifyVariant.SetActive(false);
                _middleDetail.SetActive(false);
                _highDetailModifyVariant.SetActive(true);
            }
            else if (level >= _levelToHighDetail && capacityLevel >= _levelToHighDetail)
            {
                _middleDetailModifyVariant.SetActive(false);
                _middleDetail.SetActive(false);
                _highDetailModifyVariant.SetActive(false);
                _highDetail.SetActive(true);
            }

            if (level == _levelToMiddleDetail || level == _levelToHighDetail)
                _playerEffect.Play();

            DetailChanged?.Invoke();
        }

        public void Change(int level)
        {
            if (level == _levelToMiddleDetail)
            {
                _lowDetail.SetActive(false);
                _middleDetail.SetActive(true);

                _playerEffect.Play();
            }

            if (level == _levelToHighDetail)
            {
                _middleDetail.SetActive(false);
                _highDetail.SetActive(true);

                _playerEffect.Play();
            }

            DetailChanged?.Invoke();
        }
    }
}