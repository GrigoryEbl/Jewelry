using UnityEngine;
using YG;

namespace Barrier
{
    public class BarriersEnabler : MonoBehaviour
    {
        [SerializeField] private BarrierInterection _barrierJail;
        [SerializeField] private BarrierInterection _barrierForge;
        [SerializeField] private BarrierInterection _barrierThrone;

        private void OnEnable()
        {
            YandexGame.GetDataEvent += GetData;
            _barrierJail.NewZoneOpened += SaveData;
            _barrierForge.NewZoneOpened += SaveData;
            _barrierThrone.NewZoneOpened += SaveData;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= GetData;
            _barrierJail.NewZoneOpened -= SaveData;
            _barrierForge.NewZoneOpened -= SaveData;
            _barrierThrone.NewZoneOpened -= SaveData;
        }

        private void GetData()
        {
            _barrierJail.SetActive(YandexGame.savesData.IsBarrierJailActive);
            _barrierForge.SetActive(YandexGame.savesData.IsBarrierForgeActive);
            _barrierThrone.SetActive(YandexGame.savesData.IsBarrierThroneActive);
        }

        private void SaveData()
        {
            YandexGame.savesData.IsBarrierJailActive = _barrierJail.GetActiveInfo();
            YandexGame.savesData.IsBarrierForgeActive = _barrierForge.GetActiveInfo();
            YandexGame.savesData.IsBarrierThroneActive = _barrierThrone.GetActiveInfo();
            YandexGame.SaveProgress();
        }
    }
}
