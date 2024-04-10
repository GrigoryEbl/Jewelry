using UnityEngine;

namespace Barrier
{
    public class LampsEnabler : MonoBehaviour
    {
        [SerializeField] private BarrierInterection _barrierInterection;
        [SerializeField] private GameObject _lamps;

        private void OnEnable() => _barrierInterection.NewZoneOpened += TurnLamps;

        private void OnDisable() => _barrierInterection.NewZoneOpened -= TurnLamps;

        private void Start()
        {
            _lamps.SetActive(!_barrierInterection.GetActiveInfo());
        }

        private void TurnLamps()
        {
            _lamps.SetActive(true);
        }
    }
}
