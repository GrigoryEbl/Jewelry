using UnityEngine;

namespace Assets.Scripts.UI
{
    public class WheelsEventHandlerView : MonoBehaviour
    {
        [SerializeField] private DetailView _detailView;

        public void OnInfoChange()
        {
            _detailView.ChangeInfo(_detailView.Upgrader.PriceUpgradeWheels, _detailView.PlayerCar.WheelsLevel);
        }
    }
}