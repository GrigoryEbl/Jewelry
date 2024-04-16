using Assets.Scripts.Car.Details;
using Assets.Scripts.Car;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class DetailView : MonoBehaviour
    {
        [SerializeField] private Upgrader _upgrader;
        [SerializeField] private PlayerCar _playerCar;
        [SerializeField] private DetailChanger _changer;

        [SerializeField] private TMP_Text _maxFillLevel;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _imageMiddleDetail;
        [SerializeField] private Image _imageHighDetail;

        public PlayerCar PlayerCar => _playerCar;
        public Upgrader Upgrader => _upgrader;

        public void ChangeInfo(int priceUpgreadeDetail, int detailLevel)
        {
            ChangeText(_priceText, priceUpgreadeDetail, _levelText, detailLevel, _label);
            SetImageDetail(detailLevel, _changer.LevelToMiddleDetail, _imageMiddleDetail, _imageHighDetail);
            Slide(_slider, detailLevel);
        }

        private void ChangeText(TMP_Text price, float priceInfo, TMP_Text level, int levelInfo, TMP_Text label)
        {
            if (levelInfo >= _upgrader.MaxLevel)
            {
                label.enabled = false;
                level.enabled = false;
                _maxFillLevel.gameObject.SetActive(true);
            }

            price.text = $"${priceInfo.ToString("F0")}";
            level.text = $"{levelInfo}";
        }

        private void SetImageDetail(int levelinfo, int levelToMiddleDetail, Image middleDetail, Image highDetail)
        {
            if (levelinfo >= levelToMiddleDetail)
            {
                middleDetail.gameObject.SetActive(false);
                highDetail.gameObject.SetActive(true);
            }
        }

        private void Slide(Slider slider, int target)
        {
            slider.value = target;
        }
    }
}