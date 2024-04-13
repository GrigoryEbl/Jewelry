using UnityEngine;

namespace Assets.Scripts.UI
{
    internal class CapacityEventHandlerView : MonoBehaviour
    {
        [SerializeField] private DetailView _detailView;

        public void OnInfoChange()
        {
           _detailView.ChangeInfo(_detailView.Upgrader.PriceUpgradeCapacity, _detailView.PlayerCar.CapacityLevel);
        }  
    }
}