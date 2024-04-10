using UnityEngine;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(MagnetView))]
    [RequireComponent(typeof(WheelsView))]
    [RequireComponent(typeof(CapacityView))]
    public class UpgraderView : MonoBehaviour
    {
        [SerializeField] private Upgrader _upgrader;
        [SerializeField] private GameObject _upgradeScreen;

        private MagnetView _magnetView;
        private WheelsView _wheelsView;
        private CapacityView _capacityView;

        private void Awake()
        {
            _magnetView = GetComponent<MagnetView>();
            _wheelsView = GetComponent<WheelsView>();
            _capacityView = GetComponent<CapacityView>();
        }

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
            _upgradeScreen.SetActive(isActive);
            _magnetView.OnInfoChange();
            _wheelsView.OnInfoChange();
            _capacityView.OnInfoChange();
        }
    }
}