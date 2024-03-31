using UnityEngine;

public class LampsEnabler : MonoBehaviour
{
    [SerializeField] private BarrierInterection _barrierInterection;
    [SerializeField] private GameObject _lamps;

    private void OnEnable() => _barrierInterection.NewZoneOpened += LampsActive;

    private void OnDisable() => _barrierInterection.NewZoneOpened -= LampsActive;

    private void LampsActive()
    {
        _lamps.SetActive(true);
    }
}
