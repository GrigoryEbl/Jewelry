using UnityEngine;
using YG;

namespace Assets.Scripts.Car.Details
{
    public class Capacity : MonoBehaviour, IImprovable
    {
        private int _maxCatchCount;

        public int Level => _maxCatchCount;

        public void Init()
        {
            _maxCatchCount = YandexGame.savesData.CapacityLevel;
        }

        public void Upgrade()
        {
            _maxCatchCount++;
        }

        public void ChangeMaxCapacityCount(int addedValue)
        {
            _maxCatchCount += addedValue;
        }
    }
}