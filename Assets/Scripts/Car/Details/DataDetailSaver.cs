using UnityEngine;
using YG;

namespace Assets.Scripts.Car.Details
{
    public class DataDetailSaver : MonoBehaviour
    {
        [SerializeField] private DetailChanger _magnetChanger;
        [SerializeField] private DetailChanger _wheelsChanger;
        [SerializeField] private DetailChanger _capacityChanger;

        private void OnEnable()
        {
            YandexGame.GetDataEvent += GetLoad;
            _magnetChanger.DetailChanged += SaveData;
            _wheelsChanger.DetailChanged += SaveData;
            _capacityChanger.DetailChanged += SaveData;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= GetLoad;
            _magnetChanger.DetailChanged -= SaveData;
            _wheelsChanger.DetailChanged -= SaveData;
            _capacityChanger.DetailChanged -= SaveData;
        }

        private void SaveData()
        {
            SelectActiveObjects(_magnetChanger.transform, YandexGame.savesData.IsMagnetModelsActive, false);
            SelectActiveObjects(_wheelsChanger.transform, YandexGame.savesData.IsWheelsModelsActive, false);
            SelectActiveObjects(_capacityChanger.transform, YandexGame.savesData.IsHandModelsActive, false);
            YandexGame.SaveProgress();
        }

        private void GetLoad()
        {
            SelectActiveObjects(_magnetChanger.transform, YandexGame.savesData.IsMagnetModelsActive, true);
            SelectActiveObjects(_wheelsChanger.transform, YandexGame.savesData.IsWheelsModelsActive, true);
            SelectActiveObjects(_capacityChanger.transform, YandexGame.savesData.IsHandModelsActive, true);
        }

        private void SelectActiveObjects(Transform details, bool[] savesObjects, bool isLoadData)
        {
            if (isLoadData == false)
                for (int i = 0; i < details.childCount; i++)
                {
                    savesObjects[i] = details.GetChild(i).gameObject.activeSelf;
                }
            else
                for (int i = 0; i < details.childCount; i++)
                {
                    details.GetChild(i).gameObject.SetActive(savesObjects[i]);
                }
        }
    }
}