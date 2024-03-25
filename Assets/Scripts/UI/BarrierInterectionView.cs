using TMPro;
using UnityEngine;

public class BarrierInterectionView : MonoBehaviour
{
    [SerializeField] private BarrierInterection _barrierInterection;
    [SerializeField] private GameObject _barrierInterectionScreen;
    [SerializeField] private TMP_Text _PriceText;

    private void OnEnable()
    {
        _barrierInterection.BarrierReach += ShowInfo;
        _barrierInterectionScreen.SetActive(false);
    }

    private void OnDisable()
    {
        _barrierInterection.BarrierReach -= ShowInfo;
    }

    private void ShowInfo(bool isActive)
    {
        _barrierInterectionScreen.SetActive(isActive);
        _PriceText.text = "$" + _barrierInterection.Price;
    }
}
