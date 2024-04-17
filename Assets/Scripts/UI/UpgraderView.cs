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
            _upgrader.MagnetCharacteristiscsChanged += _magnetView.ChangeInfo;
            _upgrader.WheelsCharacteristiscsChanged += _wheelsView.ChangeInfo;
            _upgrader.CapacityCharacteristiscsChanged += _capacityView.ChangeInfo;
        }

        private void OnDisable()
        {
            _upgrader.UpgradeZoneReached -= OnUpgradeZoneReach;
            _upgrader.MagnetCharacteristiscsChanged -= _magnetView.ChangeInfo;
            _upgrader.WheelsCharacteristiscsChanged -= _wheelsView.ChangeInfo;
            _upgrader.CapacityCharacteristiscsChanged -= _capacityView.ChangeInfo;
        }

        private void OnUpgradeZoneReach(bool isActive)
        {
            _magnetPanel.SetActive(isActive);
            _wheelsPanel.SetActive(isActive);
            _capacityPanel.SetActive(isActive);
        }
    }
}