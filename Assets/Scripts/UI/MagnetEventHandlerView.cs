using UnityEngine;

namespace Assets.Scripts.UI
{
    public class MagnetEventHandlerView : MonoBehaviour
    {
        [SerializeField] private DetailView _detailView;

        public void OnInfoChange()
        {
           _detailView.ChangeInfo(_detailView.Upgrader.PriceUpgradeMagnet, _detailView.PlayerCar.MagnetLevel);
        }
    }
}