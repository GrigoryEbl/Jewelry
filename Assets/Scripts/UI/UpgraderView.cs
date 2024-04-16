using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UpgraderView : MonoBehaviour
    {
        [SerializeField] private Upgrader _upgrader;

        [SerializeField] private GameObject _magnetPanel;
        [SerializeField] private GameObject _wheelsPanel;
        [SerializeField] private GameObject _capacityPanel;

        [SerializeField] private DetailView _magnetView;
        [SerializeField] private DetailView _wheelsView;
        [SerializeField] private DetailView _capacityView;

        private void OnEnable()
        {
            _upgrader.UpgradeZoneReached += OnUpgradeZoneReach;
            _upgrader.CharacteristiscsChanged += _magnetView.ChangeInfo;
            _upgrader.CharacteristiscsChanged += _wheelsView.ChangeInfo;
            _upgrader.CharacteristiscsChanged += _capacityView.ChangeInfo;
        }

        private void OnDisable()
        {
            _upgrader.UpgradeZoneReached -= OnUpgradeZoneReach;
            _upgrader.CharacteristiscsChanged -= _magnetView.ChangeInfo;
            _upgrader.CharacteristiscsChanged -= _wheelsView.ChangeInfo;
            _upgrader.CharacteristiscsChanged -= _capacityView.ChangeInfo;
        }

        private void OnUpgradeZoneReach(bool isActive)
        {
            _magnetPanel.SetActive(isActive);
            _wheelsPanel.SetActive(isActive);
            _capacityPanel.SetActive(isActive);

            _magnetView.ChangeInfo((int)_magnetView.Upgrader.PriceUpgradeMagnet, _magnetView.PlayerCar.MagnetLevel);
            _wheelsView.ChangeInfo((int)_wheelsView.Upgrader.PriceUpgradeWheels, _wheelsView.PlayerCar.WheelsLevel);
            _capacityView.ChangeInfo((int)_capacityView.Upgrader.PriceUpgradeCapacity, _capacityView.PlayerCar.CapacityLevel);
        }
    }
}