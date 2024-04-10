using UnityEngine;
using TMPro;
using PlayerCar;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MagnetView : MonoBehaviour, IUpgraderViewer
    {
        [SerializeField] private Upgrader _upgrader;
        [SerializeField] private Car _car;
        [SerializeField] private MagnetChanger _magnetChanger;

        [SerializeField] private TMP_Text _maxFillLevel;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _imageMiddleDetail;
        [SerializeField] private Image _imageHighDetail;

        public void OnInfoChange()
        {
            ChangeText(_priceText, _upgrader.PriceUpgradeMagnet, _levelText, _car.MagnetLevel, _label);
            Slide(_slider, _car.MagnetLevel);
            SetImageDetail(_car.MagnetLevel, _magnetChanger.LevelToMiddleMagnet, _imageMiddleDetail, _imageHighDetail);
        }

        public void ChangeText(TMP_Text price, float priceInfo, TMP_Text level, int levelInfo, TMP_Text label)
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

        public void SetImageDetail(int levelinfo, int levelToMiddleDetail, Image middleDetail, Image highDetail)
        {
            if (levelinfo >= levelToMiddleDetail)
            {
                middleDetail.gameObject.SetActive(false);
                highDetail.gameObject.SetActive(true);
            }
        }

        public void Slide(Slider slider, int target)
        {
            slider.value = target;
        }
    }
}