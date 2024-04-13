using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UpgraderView : MonoBehaviour
    {
        [SerializeField] private Upgrader _upgrader;

        [SerializeField] private GameObject _magnetPanel;
        [SerializeField] private GameObject _wheelsPanel;
        [SerializeField] private GameObject _capacityPanel;

        [SerializeField] private MagnetEventHandlerView _magnetView;
        [SerializeField] private WheelsEventHandlerView _wheelsView;
        [SerializeField] private CapacityEventHandlerView _capacityView;

        private void OnEnable()
        {
            _upgrader.UpgradeZoneReached += OnUpgradeZoneReach;
            _upgrader.CharacteristiscsChanged += _magnetView.OnInfoChange;
            _upgrader.CharacteristiscsChanged += _wheelsView.OnInfoChange;
            _upgrader.CharacteristiscsChanged += _capacityView.OnInfoChange;
        }

        private void OnDisable()
        {
            _upgrader.UpgradeZoneReached -= OnUpgradeZoneReach;
            _upgrader.CharacteristiscsChanged -= _magnetView.OnInfoChange;
            _upgrader.CharacteristiscsChanged -= _wheelsView.OnInfoChange;
            _upgrader.CharacteristiscsChanged -= _capacityView.OnInfoChange;
        }

        private void OnUpgradeZoneReach(bool isActive)
        {
            _magnetPanel.SetActive(isActive);
            _wheelsPanel.SetActive(isActive);
            _capacityPanel.SetActive(isActive);

            _magnetView.OnInfoChange();
            _wheelsView.OnInfoChange();
            _capacityView.OnInfoChange();
        }
    }
}