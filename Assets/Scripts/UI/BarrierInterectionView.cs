using Barrier;
using TMPro;
using UnityEngine;

namespace UI
{
    public class BarrierInterectionView : MonoBehaviour
    {
        [SerializeField] private BarrierInterection _barrierInterection;
        [SerializeField] private GameObject _barrierInterectionScreen;
        [SerializeField] private TMP_Text _PriceText;

        private void OnEnable()
        {
            _barrierInterection.BarrierReached += ShowInfo;
            _barrierInterectionScreen.SetActive(false);
        }

        private void OnDisable()
        {
            _barrierInterection.BarrierReached -= ShowInfo;
        }

        private void ShowInfo(bool isActive)
        {
            _barrierInterectionScreen.SetActive(isActive);
            _PriceText.text = "$" + _barrierInterection.Price;
        }
    }
}
