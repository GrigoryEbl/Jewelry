using System.Collections;
using UnityEngine;
using YG;

public class BarriersActivity : MonoBehaviour
{
    [SerializeField] private Transform _barrierJail;
    [SerializeField] private Transform _barrierForge;
    [SerializeField] private Transform _barrierThrone;

    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    private void Start()
    {
        StartCoroutine(BarrierDataSave());
    }

    private IEnumerator BarrierDataSave()
    {
        while(true)
        {
            SaveData();

            yield return new WaitForSeconds(5);
        }
    }

    private void GetData()
    {
        _barrierJail.gameObject.SetActive(YandexGame.savesData.IsBarrierJailActive);
        _barrierForge.gameObject.SetActive(YandexGame.savesData.IsBarrierForgeActive);
        _barrierThrone.gameObject.SetActive(YandexGame.savesData.IsBarrierThroneActive);
    }

    private void SaveData()
    {
        YandexGame.savesData.IsBarrierJailActive = _barrierJail.gameObject.activeSelf;
        YandexGame.savesData.IsBarrierForgeActive = _barrierForge.gameObject.activeSelf;
        YandexGame.savesData.IsBarrierThroneActive = _barrierThrone.gameObject.activeSelf;
        YandexGame.SaveProgress();
    }
}
