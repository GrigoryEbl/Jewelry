using UnityEngine;

public class CapacityIndicator : MonoBehaviour
{
    [SerializeField] private Magnet _hand;
    [SerializeField] private Transform[] _lamps;

    private void OnEnable() => _hand.ResourceCatched += ChangeIndicator;

    private void OnDisable() => _hand.ResourceCatched -= ChangeIndicator;

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
        float percent = ((float)value / (float)_hand.MaxCapacityCount) * multiplier;
        return percent;
    }
}
