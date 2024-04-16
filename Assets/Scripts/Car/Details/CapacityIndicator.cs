using UnityEngine;

namespace Assets.Scripts.Car.Details
{
    public class CapacityIndicator : MonoBehaviour
    {
        [SerializeField] private Magnet _magnet;
        [SerializeField] private Transform[] _lamps;
        
        private void OnEnable() => _magnet.ResourceChangedCount += ChangeIndicator;

        private void OnDisable() => _magnet.ResourceChangedCount -= ChangeIndicator;

        private void ChangeIndicator(int resourceCount)
        {
            float percent = CalculatePercent(resourceCount);

            _lamps[0].gameObject.SetActive(percent >= 25);
            _lamps[1].gameObject.SetActive(percent >= 50);
            _lamps[2].gameObject.SetActive(percent >= 75);
            _lamps[3].gameObject.SetActive(percent >= 100);
        }

        private float CalculatePercent(int value)
        {
            int multiplier = 100;
            float percent = ((float)value / (float)_magnet.MaxCapacityCount) * multiplier;
            return percent;
        }
    }
}